using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketBinaryEnCodingGenerator
{
    public class GenerateCppEnDecoder
    {
        public List<string> FullSourceCode = new List<string>();
        public List<string> TempletCode = new List<string>();
        public List<string> GeneratedCode = new List<string>();


        public ERROR_CODE Generate(string sourceNamespace, 
                                    string packetDataHeaderFile, 
                                Dictionary<string, StructInfo> 구조체정의_사전)
        {
            Clear();

            var result = LoadFile("Templete\\CppEnDecoderTemplete.txt", TempletCode);
            if(result != ERROR_CODE.NONE)
            {
                return result;
            }

            if (string.IsNullOrEmpty(sourceNamespace) == false)
            {
                for(int i = 0; i < TempletCode.Count(); ++i )
                {
                    if (TempletCode[i].IndexOf("namespace ") == 0)
                    {
                        TempletCode[i] = string.Format("namespace {0} ", sourceNamespace);
                        break;
                    }
                }
            }

            TempletCode.Insert(6, string.Format("#include \"{0}\"", packetDataHeaderFile));
            

            result = GenerateEnDecoderClass(구조체정의_사전, GeneratedCode);
            if(result != ERROR_CODE.NONE)
            {
                return result;
            }


            FullSourceCode.AddRange(TempletCode);
            FullSourceCode.AddRange(GeneratedCode);
            FullSourceCode.Add("}");

            return ERROR_CODE.NONE;
        }

        void Clear()
        {
            FullSourceCode.Clear();
            TempletCode.Clear();
            GeneratedCode.Clear();
        }

        ERROR_CODE LoadFile(string fileName, List<string> TempletString)
        {
            if (System.IO.File.Exists(fileName) == false)
            {
                return ERROR_CODE.ERROR_TEMPLETE_FILE_EXISTS;
            }

            var sr = new System.IO.StreamReader(fileName);
            while (sr.Peek() >= 0)
            {
                TempletString.Add(sr.ReadLine());
            }

            return ERROR_CODE.NONE;
        }

        ERROR_CODE GenerateEnDecoderClass(Dictionary<string, StructInfo> 구조체정의_사전, List<string> GenerateCode)
        {
            foreach (var structInfo in 구조체정의_사전.Values)
            {
                if (structInfo.IsPassEnDecodeGenerate)
                {
                    continue;
                }

                GenerateCode.Add(string.Format("\tstruct EnDecode{0} ", structInfo.Name));
                GenerateCode.Add("\t{ ");

                변수_만들기(structInfo.DefineDataBufferSize, GenerateCode);
                초기화_함수_만들기(GenerateCode);
                엔코드_함수_만들기(구조체정의_사전, structInfo, GenerateCode);
                디코드_함수_만들기(구조체정의_사전, structInfo, GenerateCode);

                GenerateCode.Add("\t}; ");
                GenerateCode.Add("");
            }

            return ERROR_CODE.NONE;
        }

        void 변수_만들기(int bufferSize, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("\t\tchar m_Buffer[{0}];", bufferSize));
            GenerateCode.Add(string.Format("\t\tchar m_TempBuffer[{0}];", bufferSize));
            GenerateCode.Add(string.Format("\t\tshort MaxBufferSize = {0};", bufferSize));
            GenerateCode.Add("");
        }

        void 초기화_함수_만들기(List<string> GenerateCode)
        {
            GenerateCode.Add("\t\tchar* Encode_Init(char* OutPutBuffer, int OutPutBufferSize)");
            GenerateCode.Add("\t\t{");
            GenerateCode.Add("\t\t\tif (OutPutBuffer != nullptr)");
            GenerateCode.Add("\t\t\t{");
            GenerateCode.Add("\t\t\t\tMaxBufferSize = OutPutBufferSize;");
            GenerateCode.Add("\t\t\t\treturn OutPutBuffer;");
            GenerateCode.Add("\t\t\t}");
            GenerateCode.Add("");
            GenerateCode.Add("\t\t\treturn m_Buffer;");
            GenerateCode.Add("\t\t}");
            GenerateCode.Add("");
        }

        void 엔코드_함수_만들기(Dictionary<string, StructInfo> 구조체정의_사전, StructInfo structInfo, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("\t\tbool Encode({0}& PacketData, short RegionID, short PacketID, char* OutPutBuffer, int OutPutBufferSize)", structInfo.Name));
            GenerateCode.Add("\t\t{");
            GenerateCode.Add("\t\t\tshort UseSize = 0;");
            GenerateCode.Add("\t\t\tshort WritePos = PACKET_HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작");
            GenerateCode.Add("\t\t\tchar* pBuffer = Encode_Init(OutPutBuffer, OutPutBufferSize);");
            GenerateCode.Add("\t\t\tmemset(pBuffer, 0, MaxBufferSize);");
            GenerateCode.Add("");

            엔코드_멤버데이터_구조체("\t\t\t", 구조체정의_사전, structInfo, "PacketData", GenerateCode);
                        
            GenerateCode.Add("\t\t\tshort BodySize = WritePos - PACKET_HEADER_SIZE;");
            GenerateCode.Add("\t\t\tEncoder::WriteNumber<short>(RegionID, pBuffer, 0);");
            GenerateCode.Add("\t\t\tEncoder::WriteNumber<short>(PacketID, pBuffer, 2);");
            GenerateCode.Add("\t\t\tEncoder::WriteNumber<short>(BodySize, pBuffer, 4);");
            GenerateCode.Add("\t\t\treturn true;");
            GenerateCode.Add("\t\t}");
            GenerateCode.Add("");
        }

        void 엔코드_멤버데이터_구조체(string indent, Dictionary<string, StructInfo> 구조체정의_사전, StructInfo structInfo, string packetDataName, List<string> GenerateCode)
        {
            int fieldIndex = -1;
            MemberDataInfo prevMemberInfo = null;
            foreach (var memberInfo in structInfo.MemberList)
            {
                ++fieldIndex;
                if (fieldIndex > 0)
                {
                    prevMemberInfo = structInfo.MemberList[fieldIndex - 1];
                }

                if (CheckDataType.IsCppNumberType(memberInfo.Type))
                {
                    if (memberInfo.ArrayValue > 1)
                    {
                        엔코드_멤버데이터_정수배열(indent, prevMemberInfo, memberInfo, packetDataName, GenerateCode);
                    }
                    else
                    {
                        엔코드_멤버데이터_정수(indent, memberInfo, packetDataName, GenerateCode);
                    }
                }
                else if (CheckDataType.IsCppUnicodeCharacterType(memberInfo.Type))
                {
                    엔코드_멤버데이터_문자열(indent, memberInfo, packetDataName, GenerateCode);
                }
                else // 구조체
                {                    
                    var structInfo2 = 구조체정의_사전[memberInfo.Type];

                    if (memberInfo.ArrayValue <= 1)
                    {
                        var rePacketDataName = string.Format("{0}.{1}", packetDataName, memberInfo.Name);
                        엔코드_멤버데이터_구조체(indent, 구조체정의_사전, structInfo2, rePacketDataName, GenerateCode);
                    }
                    else
                    {
                        var rePacketDataName = string.Format("{0}.{1}[i]", packetDataName, memberInfo.Name);
                        var arrayValuePrevMemberName = prevMemberInfo.Name;

                        GenerateCode.Add(string.Format("{0}for(int i = 0; i < {1}; ++i)", indent, arrayValuePrevMemberName));
                        
                        GenerateCode.Add(indent+ "{");
                        엔코드_멤버데이터_구조체("\t"+indent, 구조체정의_사전, structInfo2, rePacketDataName, GenerateCode);
                        GenerateCode.Add(indent + "}");
                        GenerateCode.Add("");
                    }
                }
            }
        }

        void 엔코드_멤버데이터_정수배열(string indent, MemberDataInfo prevMemberInfo, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            var arrayValuePrevMemberName = prevMemberInfo.Name;

            GenerateCode.Add(string.Format("{0}memcpy(&pBuffer[WritePos], {1}.{2}, sizeof({3})*PacketData.{4});", indent, packetDataName, memberInfo.Name, memberInfo.Type, arrayValuePrevMemberName));
            GenerateCode.Add(string.Format("{0}UseSize = (sizeof({1}) * {2}.{3});", indent, memberInfo.Type, packetDataName, arrayValuePrevMemberName));
                        
            GenerateCode.Add(indent + "WritePos += UseSize;");
            GenerateCode.Add("");
        }

        void 엔코드_멤버데이터_정수(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}UseSize = Encoder::WriteNumber<{1}>({2}.{3}, pBuffer, WritePos);", indent, memberInfo.Type, packetDataName, memberInfo.Name));
            GenerateCode.Add(indent + "WritePos += UseSize;");
            GenerateCode.Add("");
        }

        void 엔코드_멤버데이터_문자열(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}UseSize = Encoder::WriteWChar({1}.{2}, pBuffer, WritePos, MaxBufferSize);", indent, packetDataName, memberInfo.Name));
            GenerateCode.Add(indent + "WritePos += UseSize;");
            GenerateCode.Add("");
        }
                

        void 디코드_함수_만들기(Dictionary<string, StructInfo> 구조체정의_사전, StructInfo structInfo, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("\t\tbool Decode(char* pBuffer, {0}& PacketData)", structInfo.Name));
            GenerateCode.Add("\t\t{");
            GenerateCode.Add("\t\t\tshort ReadSize = 0;");
            GenerateCode.Add("\t\t\tshort ReadPos = PACKET_HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작");
            GenerateCode.Add("");

            디코드_멤버데이터_구조체("\t\t\t", 구조체정의_사전, structInfo, "PacketData", GenerateCode);
            
            GenerateCode.Add("\t\t\treturn true;");
            GenerateCode.Add("\t\t}");
            GenerateCode.Add("");
        }

        void 디코드_멤버데이터_구조체(string indent, Dictionary<string, StructInfo> 구조체정의_사전, StructInfo structInfo, string packetDataName, List<string> GenerateCode)
        {
            int fieldIndex = -1;
            MemberDataInfo prevMemberInfo = null;
            foreach (var memberInfo in structInfo.MemberList)
            {
                ++fieldIndex;
                if (fieldIndex > 0)
                {
                    prevMemberInfo = structInfo.MemberList[fieldIndex - 1];
                }

                if (CheckDataType.IsCppNumberType(memberInfo.Type))
                {
                    if (memberInfo.ArrayValue > 1)
                    {
                        디코드_멤버데이터_정수배열(indent, prevMemberInfo, memberInfo, packetDataName, GenerateCode);
                    }
                    else
                    {
                        디코드_멤버데이터_정수(indent, memberInfo, packetDataName, GenerateCode);
                    }
                }
                else if (CheckDataType.IsCppUnicodeCharacterType(memberInfo.Type))
                {
                    디코드_멤버데이터_문자열(indent, memberInfo, packetDataName, GenerateCode);
                }
                else // 구조체
                {
                    var structInfo2 = 구조체정의_사전[memberInfo.Type];

                    if (memberInfo.ArrayValue <= 1)
                    {
                        var rePacketDataName = string.Format("{0}.{1}", packetDataName, memberInfo.Name);
                        디코드_멤버데이터_구조체(indent, 구조체정의_사전, structInfo2, rePacketDataName, GenerateCode);
                    }
                    else
                    {
                        var rePacketDataName = string.Format("{0}.{1}[i]", packetDataName, memberInfo.Name);
                        var arrayValuePrevMemberName = prevMemberInfo.Name; 

                        GenerateCode.Add(string.Format("{0}for(int i = 0; i < {1}; ++i)", indent, arrayValuePrevMemberName));
                                                
                        GenerateCode.Add(indent + "{");
                        디코드_멤버데이터_구조체("\t" + indent, 구조체정의_사전, structInfo2, rePacketDataName, GenerateCode);
                        GenerateCode.Add(indent + "}");
                        GenerateCode.Add("");
                    }
                }
            }
        }

        void 디코드_멤버데이터_정수(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}ReadSize = DeCoder::ReadNumber<{1}>({2}.{3}, pBuffer, WritePos);", indent, memberInfo.Type, packetDataName, memberInfo.Name));
            GenerateCode.Add(string.Format("{0}ReadPos += ReadSize;", indent));
            GenerateCode.Add("");
        }

        void 디코드_멤버데이터_정수배열(string indent, MemberDataInfo prevMemberInfo, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            var arrayValuePrevMemberName = "";

            if (prevMemberInfo != null)
            {
                var prevMemberName = prevMemberInfo.Name;
                var name1 = memberInfo.Name.Substring(0, memberInfo.Name.Length - 1);
                var name2 = memberInfo.Name.Last().ToString();

                if (name2 == "s" && ((name1 + "Count") == prevMemberName))
                {
                    arrayValuePrevMemberName = prevMemberName;
                }
            }

            if (string.IsNullOrEmpty(arrayValuePrevMemberName) == false)
            {
                GenerateCode.Add(string.Format("{0}memcpy({1}.{2}, &pBuffer[ReadPos], sizeof({3}) * PacketData.{4});", indent, packetDataName, memberInfo.Name, memberInfo.Type, arrayValuePrevMemberName));
                GenerateCode.Add(string.Format("{0}ReadSize = (sizeof({1}) * {2}.{3});", indent, memberInfo.Type, packetDataName, arrayValuePrevMemberName));
                
            }
            else
            {
                GenerateCode.Add(string.Format("{0}memcpy({1}.{2}, &pBuffer[ReadPos], sizeof({3}) * {4});", indent, packetDataName, memberInfo.Name, memberInfo.Type, memberInfo.ArrayDefineName));
                GenerateCode.Add(string.Format("{0}ReadSize = (sizeof({1}) * {2});", indent, memberInfo.Type, memberInfo.ArrayDefineName));
            }

            GenerateCode.Add(string.Format("{0}ReadPos += ReadSize;", indent));
            GenerateCode.Add("");
        }

        void 디코드_멤버데이터_문자열(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}ReadSize = DeCoder::ReadWChar({1}.{2}, {3}, pBuffer, ReadPos, m_TempBuffer);", indent, packetDataName, memberInfo.Name, memberInfo.ArrayDefineName));
            GenerateCode.Add(string.Format("{0}ReadPos += ReadSize;", indent));
            GenerateCode.Add("");
        }


        //string 진짜_사용할_배열_범위(MemberDataInfo prevMemberInfo, MemberDataInfo memberInfo)
        //{
        //    var arrayValuePrevMemberName = "";

        //    if (prevMemberInfo != null)
        //    {
        //        var prevMemberName = prevMemberInfo.Name;
        //        var name1 = memberInfo.Name.Substring(0, memberInfo.Name.Length - 1);
        //        var name2 = memberInfo.Name.Last().ToString();

        //        if (name2 == "s" && ((name1 + "Count") == prevMemberName))
        //        {
        //            arrayValuePrevMemberName = prevMemberName;
        //        }
        //    }

        //    return arrayValuePrevMemberName;
        //}
    }
}
