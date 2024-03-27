using System;
using System.Collections.Generic;
using System.Linq;


namespace PacketBinaryEnCodingGenerator
{
    public class GenerateCSharpPacketProtocolFile
    {
        public List<string> GeneratedCode = new List<string>();


        public ERROR_CODE GenerateCode(string useNamespace, Dictionary<string, StructInfo> 구조체정의_사전, Dictionary<string, string> 상수정의_사전)
        {
            Clear();
            /*
            var codeDom = new LinqToCodedom.CodeDomGenerator();
            var codeNamespace = codeDom.AddNamespace(useNamespace);


            var constantClass = codeNamespace.AddClass("ConstantSet");
            foreach (var 상수정보 in 상수정의_사전)
            {
                var value = Convert.ToInt32(상수정보.Value);
                constantClass.AddField(Type.GetType("System.Int32"), 
                    System.CodeDom.MemberAttributes.Public | System.CodeDom.MemberAttributes.Const, 
                    상수정보.Key, () => value);
            }


            foreach (var structInfo in 구조체정의_사전.Values)
            {
                var structClass = codeNamespace.AddClass(structInfo.Name);

                foreach(var member in structInfo.MemberList)
                {
                    var typeName = CSharpType(member);

                    if (typeName.Item1 == false)
                    {
                        structClass.AddField(Type.GetType(typeName.Item2), System.CodeDom.MemberAttributes.Public, member.Name);
                    }
                    else
                    {
                        structClass.AddFields(Define.Field(System.CodeDom.MemberAttributes.Public, typeName.Item2, member.Name));
                    }
                    
                }
            }
            
            var generateCode = codeDom.GenerateCode(LinqToCodedom.CodeDomGenerator.Language.CSharp);
            var GeneratedCode = generateCode.Split("\r\n").ToList();
            */
            return ERROR_CODE.NONE;
        }

        void Clear()
        {
            GeneratedCode.Clear();
        }

        Tuple<bool,string> CSharpType(MemberDataInfo memberInfo)
        {
            bool isSxceptionally = false;
            string csharpType = memberInfo.Type;

            switch (memberInfo.Type)
            {
                case "char":
                    csharpType = "System.SByte";
                    break;
                case "unsigned char":
                    csharpType = "System.Byte";
                    break;
                case "short":
                    csharpType = "System.Int16";
                    break;
                case "unsigned short":
                    csharpType = "System.UInt16";
                    break;
                case "int":
                    csharpType = "System.Int32";
                    break;
                case "unsigned int":
                    csharpType = "System.UInt32";
                    break;
                case "__int64":
                    csharpType = "System.Int64";
                    break;
                case "unsigned __int64":
                    csharpType = "System.UInt64";
                    break;
                case "float":
                    csharpType = "System.Single";
                    break;
                case "double":
                    csharpType = "System.Double";
                    break;
                case "wchar_t":
                    csharpType = "System.String";
                    isSxceptionally = true;
                    break;
                default:
                    isSxceptionally = true;
                    break;
            }

            if (memberInfo.ArrayValue > 1 && memberInfo.Type != "string")
            {
                csharpType = string.Format("System.Collections.Generic.List<{0}>", csharpType);
                isSxceptionally = true;
            }

            return new Tuple<bool, string>(isSxceptionally, csharpType);
        }
    }
}
