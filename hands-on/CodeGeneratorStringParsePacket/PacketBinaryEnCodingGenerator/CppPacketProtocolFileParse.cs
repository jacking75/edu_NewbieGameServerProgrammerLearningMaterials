using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketBinaryEnCodingGenerator
{
    public class CppPacketProtocolFileParse
    {
        public string FullPathFileName { get; private set; }
        public string FileName { get; private set; }
        Int16 패킷_구조체_최고_버퍼크기 = 4096;
        Int16 패킷_구조체_기본_버퍼크기 = 8;
        string PacketDataNamePrefix = "PKT";

        //                이름, 값
        public Dictionary<string, string> 상수정의_사전 = new Dictionary<string, string>();
        public Dictionary<string, StructInfo> 구조체정의_사전 = new Dictionary<string, StructInfo>();
        

        List<string> HeaderFileList = new List<string>();

        // 패킷 정의 구조체 데이터
        List<string> 패킷정의데이터 = new List<string>();
        // '패킷정의데이터' 기준으로 구조체의 시작, 끝
        List<Tuple<int, int>> 패킷정의_위치_리스트 = new List<Tuple<int, int>>();


        public ERROR_CODE ParseFile(string fullPathFileName, Int16 maxBufferSize, string packetDataNamePrefix)
        {
            Clear();

            패킷_구조체_최고_버퍼크기 = maxBufferSize;
            PacketDataNamePrefix = packetDataNamePrefix;

            FullPathFileName = fullPathFileName;
            FileName = System.IO.Path.GetFileName(fullPathFileName);

            var sr = LoadFile(FullPathFileName);
            if (sr == null)
            {
                return ERROR_CODE.ERROR_FILE_EXISTS;
            }

            var errorCode = 코드_대분류하기(sr);
            if (errorCode != ERROR_CODE.NONE)
            {
                return errorCode;
            }

            {
                var result = 구조체_정보_만들기(패킷정의데이터, 패킷정의_위치_리스트);
                if (result.Item1 != ERROR_CODE.NONE)
                {
                    return result.Item1;
                }


                // 패킷 데이터의 버퍼 크기를 구한다.
                if (상수정의_사전.ContainsKey("PACKET_HEADER_SIZE") == false)
                {
                    return ERROR_CODE.PACKET_HEADER_SIZE_DO_NOT_FIND;
                }

                var PacketHeaderSize = 상수정의_사전["PACKET_HEADER_SIZE"].ToInt16();

                foreach (var structInfo in 구조체정의_사전.Values)
                {
                    structInfo.DefineDataBufferSize += 구조체_데이터크기_구하기(구조체정의_사전, structInfo);
                    structInfo.DefineDataBufferSize += PacketHeaderSize;
                }
                
                // 너무 큰 것은 조정을 가한다.
                foreach (var structInfo in 구조체정의_사전.Values)
                {
                    if (structInfo.DefineDataBufferSize > 패킷_구조체_최고_버퍼크기)
                    {
                        structInfo.DefineDataBufferSize = 패킷_구조체_최고_버퍼크기;
                    }
                }
            }

            return ERROR_CODE.NONE;
        }

        void Clear()
        {
            상수정의_사전.Clear();
            구조체정의_사전.Clear();
            HeaderFileList.Clear();
            패킷정의데이터.Clear();
            패킷정의_위치_리스트.Clear();
        }

        System.IO.StreamReader LoadFile(string fileName)
        {
            if (System.IO.File.Exists(fileName) == false)
            {
                return null;
            }

            var sr = new System.IO.StreamReader(fileName);
            return sr;
        }

        ERROR_CODE 코드_대분류하기(System.IO.StreamReader sr)
        {
            string readLine;
            List<int> 패킷정의_시작위치_리스트 = new List<int>();

            while (sr.Peek() >= 0)
            {
                readLine = sr.ReadLine();

                if (string.IsNullOrEmpty(readLine))
                {
                    continue;
                }

                readLine = readLine.Trim();

                if (readLine.IndexOf("{") == 0 || readLine.IndexOf("};") == 0 || readLine.IndexOf("//") == 0)
                {
                    continue;
                }

                // 상수 데이터 분류
                if (readLine.IndexOf("const ") == 0)
                {
                    상수_정보만_분류(readLine);
                    continue;
                }

                // 헤더 파일 정보 분류
                if (readLine.IndexOf("#include") == 0)
                {
                    헤더파일_정보만_분류(readLine);
                    continue;
                }


                패킷정의데이터.Add(readLine);

                // 패킷 구조체 시작
                if (readLine.IndexOf("struct ") == 0)
                {
                    패킷정의_시작위치_리스트.Add(패킷정의데이터.Count() - 1);
                }
            }


            for (int i = 0; i < 패킷정의_시작위치_리스트.Count(); ++i)
            {
                if (i == (패킷정의_시작위치_리스트.Count() - 1))
                {
                    패킷정의_위치_리스트.Add(new Tuple<int, int>(패킷정의_시작위치_리스트[i], 패킷정의데이터.Count() - 1));
                }
                else
                {
                    패킷정의_위치_리스트.Add(new Tuple<int, int>(패킷정의_시작위치_리스트[i], 패킷정의_시작위치_리스트[i + 1] - 1));
                }
            }

            return ERROR_CODE.NONE;
        }

        void 상수_정보만_분류(string text)
        {
            var tokens = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var 값 = tokens[4].ReplaceByEmpty(";");
            상수정의_사전.Add(tokens[2], 값);
        }

        void 헤더파일_정보만_분류(string text)
        {
            HeaderFileList.Add(text);
        }

        Tuple<ERROR_CODE, string> 구조체_정보_만들기(List<string> codeList, List<Tuple<int, int>> packetDefineStartEndPos)
        {            
            foreach (var startEndPos in packetDefineStartEndPos)
            {
                for (int i = startEndPos.Item1; i <= startEndPos.Item2; ++i)
                {
                    if (string.IsNullOrEmpty(codeList[i]))
                    {
                        continue;
                    }

                    var tokens = codeList[i].Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Count() < 2)
                    {
                        return new Tuple<ERROR_CODE, string>(ERROR_CODE.STRUCT_PARSE_STRUCT_TOKEN_COUNT_LESS, string.Format("코드:{0}, 토큰 개수{1}", codeList[i], tokens.Count()));
                    }

                    if (tokens[0] == "struct")
                    {
                        bool isPassEnDecodeGenerate = false;
                        if (tokens[1].IndexOf(PacketDataNamePrefix) != 0)
                        {
                            isPassEnDecodeGenerate = true;
                        }

                        구조체정의_사전.Add(tokens[1], 
                                        new StructInfo { Name = tokens[1],
                                               IsPassEnDecodeGenerate = isPassEnDecodeGenerate
                                        });
                    }
                    else
                    {
                        var memberInfo = 변수_타입_이름_분리하기(tokens);
                        var 구조체 = 구조체정의_사전.Values.Last();
                        구조체.MemberList.Add(memberInfo);
                    }
                }
            }

            return new Tuple<ERROR_CODE, string>(ERROR_CODE.NONE, "성공");
        }

        bool IsBasicType(string typeName)
        {
            if (CheckDataType.Is_CppBasicType(typeName))
            {
                return true;
            }

            return false;
        }

        MemberDataInfo 변수_타입_이름_분리하기(string[] tokens)
        {
            var member = new MemberDataInfo();
            
            if (tokens[0] == "unsigned")
            {
                member.Type = tokens[0] + " " + tokens[1];
                member.Name = tokens[2];
            }
            else
            {
                member.Type = tokens[0];
                member.Name = tokens[1];
            }

            if (member.ArrayValue == 0)
            {
                var temp = 이름_배열크기_분리하기(member.Name);
                member.Name = temp.Item1;
                member.ArrayValue = temp.Item2;
                member.ArrayDefineName = temp.Item3;
            }

            return member;
        }

        Tuple<string, int, string> 이름_배열크기_분리하기(string code)
        {
            var 이름 = "";
            var 배열크기 = 1;
            var 배열크기_DefineName = "";

            var 주석위치 = code.IndexOf("//");
            var 배열시작 = code.IndexOf("[");
            var 배열끝 = code.IndexOf("]");
            var 세미클론위치 = code.IndexOf(";");

            if (배열시작 > 0 && 배열끝 > 0)
            {
                bool 배열이다 = true;

                if (주석위치 >= 0 && 배열시작 >= 주석위치)
                {
                    배열이다 = false;
                }

                if (배열이다)
                {
                    배열크기_DefineName = code.Substring(배열시작 + 1, (배열끝 - 배열시작) - 1).Trim();

                    if (배열크기_DefineName.IsNumeric() == false)
                    {
                        if (상수정의_사전.ContainsKey(배열크기_DefineName))
                        {
                            배열크기 = 상수정의_사전[배열크기_DefineName].ToInt32();
                        }
                        else
                        {
                            throw new System.Exception("상수가 없다!!!");
                        }
                    }
                }

                이름 = code.Substring(0, 배열시작).Trim();
            }
            else
            {
                이름 = code.Substring(0, 세미클론위치).Trim();
            }

            return new Tuple<string, int, string>(이름, 배열크기, 배열크기_DefineName);
        }

        short 구조체_데이터크기_구하기(Dictionary<string, StructInfo> structMap, StructInfo structInfo)
        {
            short totalSize = 0;
            
            foreach (var memberInfo in structInfo.MemberList)
            {
                if (IsBasicType(memberInfo.Type))
                {
                    if (memberInfo.ArrayValue > 0)
                    {
                        totalSize += (short)(4 * memberInfo.ArrayValue);
                    }
                    else
                    {
                        return 패킷_구조체_기본_버퍼크기;
                    }
                }
                else
                {
                    if (structMap.ContainsKey(memberInfo.Type))
                    {
                        totalSize += 구조체_데이터크기_구하기(structMap, structMap[memberInfo.Type]);
                    }
                    else
                    {
                        throw new System.Exception("구조체를 찾을 수 없습니다.");
                    }
                }
            }

            return totalSize;
        }
    }
}
