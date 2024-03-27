using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketBinaryEnCodingGenerator
{
    public class GenerateCSharpEnDecoder
    {
        public List<string> FullSourceCode = new List<string>();
        public List<string> TempletCode = new List<string>();
        public List<string> GeneratedCode = new List<string>();


        public ERROR_CODE Generate(string sourceNamespace, Dictionary<string, StructInfo> 구조체정의_사전)
        {
            Clear();

            var result = LoadFile("Templete\\CSharpEnDecoderTemplete.txt", TempletCode);
            if (result != ERROR_CODE.NONE)
            {
                return result;
            }

            if (string.IsNullOrEmpty(sourceNamespace) == false)
            {
                for (int i = 0; i < TempletCode.Count(); ++i)
                {
                    if (TempletCode[i].IndexOf("namespace ") == 0)
                    {
                        TempletCode[i] = string.Format("namespace {0} ", sourceNamespace);
                        break;
                    }
                }
            }


            result = GenerateEnDecoderClass(구조체정의_사전, GeneratedCode);
            if (result != ERROR_CODE.NONE)
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

                GenerateCode.Add(string.Format("\tpublic class EnDecode{0} ", structInfo.Name));
                GenerateCode.Add("\t{ ");

                string indent = "\t\t";
                엔코드_함수_만들기(indent, 구조체정의_사전, structInfo, GenerateCode);
                디코드_함수_만들기(indent, 구조체정의_사전, structInfo, GenerateCode);

                GenerateCode.Add("\t} ");
                GenerateCode.Add("");
            }

            return ERROR_CODE.NONE;
        }


        void 엔코드_함수_만들기(string indent, Dictionary<string, StructInfo> 구조체정의_사전, StructInfo structInfo, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}public static void Encode(List<byte> packetData, {1} packet)", indent, structInfo.Name));
            GenerateCode.Add(indent + "{");

            var indent2 = indent + "\t";
            엔코드_멤버데이터_구조체(indent2, 구조체정의_사전, structInfo, "packet", GenerateCode);

            GenerateCode.Add(indent + "}");
            GenerateCode.Add("");
        }

        void 엔코드_멤버데이터_구조체(string indent, Dictionary<string, StructInfo> 구조체정의_사전, 
                                    StructInfo structInfo, string packetDataName, 
                                    List<string> GenerateCode)
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

                if (CheckDataType.IsCppNumberType(memberInfo.Type) || CheckDataType.IsCSharpNumberType(memberInfo.Type))
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
                else if (CheckDataType.IsCppUnicodeCharacterType(memberInfo.Type) ||
                        CheckDataType.IsCSharpCharacterType(memberInfo.Type) )
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

                        GenerateCode.Add(indent + "{");
                        엔코드_멤버데이터_구조체("\t" + indent, 구조체정의_사전, structInfo2, rePacketDataName, GenerateCode);
                        GenerateCode.Add(indent + "}");
                        GenerateCode.Add("");
                    }
                }
            }
        }

        void 엔코드_멤버데이터_정수배열(string indent, MemberDataInfo prevMemberInfo, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}PacketEnDecodeUtil.ArrayTo({1}.{2}, packetData));",
                                            indent, packetDataName, memberInfo.Name));
            GenerateCode.Add("");
        }

        void 엔코드_멤버데이터_정수(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}packetData.AddRange(BitConverter.GetBytes({1}.{2}));", 
                                            indent, packetDataName, memberInfo.Name));
            GenerateCode.Add("");
        }

        void 엔코드_멤버데이터_문자열(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}PacketEnDecodeUtil.StringTo({1}.{2}, packetData);",
                                        indent, packetDataName, memberInfo.Name));
            GenerateCode.Add("");
        }


        void 디코드_함수_만들기(string indent, Dictionary<string, StructInfo> 구조체정의_사전, StructInfo structInfo, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}public static bool Decode(byte[] packetData, ref {1} packet)", indent, structInfo.Name));
            GenerateCode.Add(indent + "{");

            string indent2 = indent + "\t";
            GenerateCode.Add(string.Format("{0}int readPos = 0;", indent2));
            GenerateCode.Add("");

            디코드_멤버데이터_구조체(indent2, 구조체정의_사전, structInfo, "PacketData", GenerateCode);

            GenerateCode.Add(indent2 + "treturn true;");
            GenerateCode.Add(indent + "}");
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

                if (CheckDataType.IsCppNumberType(memberInfo.Type) ||
                        CheckDataType.IsCSharpNumberType(memberInfo.Type)
                    )
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
                else if (CheckDataType.IsCppUnicodeCharacterType(memberInfo.Type) ||
                            CheckDataType.IsCSharpCharacterType(memberInfo.Type)
                        )
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
                        디코드_멤버데이터_구조체(indent + "\t", 구조체정의_사전, structInfo2, rePacketDataName, GenerateCode);
                        GenerateCode.Add(indent + "}");
                        GenerateCode.Add("");
                    }
                }
            }
        }

        void 디코드_멤버데이터_정수(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            var convertTypeAndSize = CppTypeToCLRConvertType(memberInfo.Type);

            GenerateCode.Add(string.Format("{0}{1}.{2} = BitConverter.{3}(packetData, readPos);",
                                    indent, packetDataName, memberInfo.Name, convertTypeAndSize.Item1));
            GenerateCode.Add(string.Format("{0}readPos += {1}", indent, convertTypeAndSize.Item2));
            GenerateCode.Add("");
        }

        void 디코드_멤버데이터_정수배열(string indent, MemberDataInfo prevMemberInfo, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}PacketEnDecodeUtil.ToCollection(packetData, ref readPos, {1}.{2}, {3});",
                                            indent, packetDataName, prevMemberInfo, memberInfo.Name));
            GenerateCode.Add("");
        }

        void 디코드_멤버데이터_문자열(string indent, MemberDataInfo memberInfo, string packetDataName, List<string> GenerateCode)
        {
            GenerateCode.Add(string.Format("{0}PacketEnDecodeUtil.ToString(packetData, ref readPos, ref {1}.{2});", 
                                            indent, packetDataName, memberInfo.Name));            
            GenerateCode.Add("");
        }


        Tuple<string, int> CppTypeToCLRConvertType(string cppType)
        {
            string csharpConvertType;
            int size = 0;

            switch (cppType)
            {
                case "char":
                    csharpConvertType = "ToInt8";
                    size = 1;
                    break;
                case "unsigned char":
                    csharpConvertType = "ToUInt8";
                    size = 1;
                    break;
                case "short":
                    csharpConvertType = "ToInt16";
                    size = 2;
                    break;
                case "unsigned short":
                    csharpConvertType = "ToUInt16";
                    size = 2;
                    break;
                case "int":
                    csharpConvertType = "ToInt32";
                    size = 4;
                    break;
                case "unsigned int":
                    csharpConvertType = "ToUInt32";
                    size = 4;
                    break;
                case "__int64":
                    csharpConvertType = "ToInt64";
                    size = 8;
                    break;
                case "unsigned __int64":
                    csharpConvertType = "ToUInt64";
                    size = 8;
                    break;
                case "float":
                    csharpConvertType = "ToSingle";
                    size = 4;
                    break;
                case "double":
                    csharpConvertType = "ToDouble";
                    size = 8;
                    break;
                default:
                    csharpConvertType = "Unknown";
                    break;
            }

            return new Tuple<string, int>(csharpConvertType, size);
        }



    }
}
