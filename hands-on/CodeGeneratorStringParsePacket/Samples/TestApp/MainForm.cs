using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PacketBinaryEnCodingGenerator;

namespace PacketEnDeCodeGeneratorForm
{
    public partial class MainForm : Form
    {
        CodeGenerator 코드생성기 = new CodeGenerator();


        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxPacketEnDecoder.Items.Clear();
            listBoxPacketStructInfo.Items.Clear();
            listBoxCSharpPacketData.Items.Clear();
            listBoxCSharpPacketEnDecoder.Items.Clear();

            
            Int16 maxBufferSize = 4096;
            string packetDataNamePrefix = "PKT";

            var fileLoadingResult = 코드생성기.CppParse.ParseFile(
                                                        textBoxCppProtocolFile.Text, 
                                                        maxBufferSize, 
                                                        packetDataNamePrefix);
            if (fileLoadingResult != ERROR_CODE.NONE)
            {
                MessageBox.Show("파일 로딩 실패");
                return;
            }


            var result1 = 코드생성기.CppPacketEnDecode.Generate("test", 
                                        "test", 
                                        코드생성기.CppParse.구조체정의_사전);

            var result2 = 코드생성기.CSharpPacketData.GenerateCode("test", 
                                    코드생성기.CppParse.구조체정의_사전, 
                                    코드생성기.CppParse.상수정의_사전);

            var result3 = 코드생성기.CSharpPacketEnDecode.Generate("test", 
                                    코드생성기.CppParse.구조체정의_사전);
            

            Cpp_분석_코드생성_UI출력(코드생성기.CppParse.구조체정의_사전,
                                  코드생성기.CppPacketEnDecode.GeneratedCode,
                                  코드생성기.CSharpPacketData.GeneratedCode,
                                  코드생성기.CSharpPacketEnDecode.GeneratedCode);

            

        }

        void Cpp_분석_코드생성_UI출력(Dictionary<string, StructInfo> 구조체정의_사전,
                            List<string> 생성된Cpp엔디코드,
                            List<string> 생성된CSharpPacketData코드, 
                            List<string> 생성된CSharp엔디코드)
        {
            string outputText;

            foreach (var structInfo in 구조체정의_사전.Values)
            {
                outputText = structInfo.Name + " ";
                for (int i = 0; i <= (28 - structInfo.Name.Length); ++i)
                {
                    outputText += " "; 
                }

                foreach (var member in structInfo.MemberList)
                {
                    outputText += string.Format("{0},{1},{2},{3}  ", member.Type, member.Name, member.ArrayValue, member.ArrayDefineName);
                }

                listBoxPacketStructInfo.Items.Add(outputText);
                listBoxPacketStructInfo.Items.Add("-----------------");
            }

            listBoxPacketStructInfo.Refresh();


            foreach (var code in 생성된Cpp엔디코드)
            {
                listBoxPacketEnDecoder.Items.Add(code);
            }

            listBoxPacketEnDecoder.Refresh();


            foreach(var code in 생성된CSharpPacketData코드)
            {
                listBoxCSharpPacketData.Items.Add(code);
            }

            listBoxCSharpPacketData.Refresh();


            foreach (var code in 생성된CSharp엔디코드)
            {
                listBoxCSharpPacketEnDecoder.Items.Add(code);
            }

            listBoxCSharpPacketEnDecoder.Refresh();
        }


        // C# 프로토콜 파일을 기준으로 소소코드 생성하기
        private void button2_Click(object sender, EventArgs e)
        {
            listBoxCSharpPacketProtocol.Items.Clear();
            listBoxCSharpPacketEnDecode.Items.Clear();
            
            string packetDataNamePrefix = "PKT";

            var fileLoadingResult = 코드생성기.CSharpParse.ParseFile(
                                                        textBoxCSharpProtocolFile.Text,
                                                        packetDataNamePrefix);
            if (fileLoadingResult != ERROR_CODE.NONE)
            {
                MessageBox.Show("파일 로딩 실패");
                return;
            }


            var result = 코드생성기.CSharpPacketEnDecode.Generate("test", 
                                           코드생성기.CSharpParse.클래스_정의_사전);


            CSharp_분석_코드생성_UI출력(코드생성기.CSharpParse.클래스_정의_사전,
                                      코드생성기.CSharpPacketEnDecode.GeneratedCode);
        }

        void CSharp_분석_코드생성_UI출력(Dictionary<string, StructInfo> 클래스_정의_사전,
                                      List<string> 생성된CSharp엔디코드)
        {
            string outputText;

            foreach (var structInfo in 클래스_정의_사전.Values)
            {
                outputText = structInfo.Name + " ";
                for (int i = 0; i <= (28 - structInfo.Name.Length); ++i)
                {
                    outputText += " ";
                }

                int seq = 0;
                foreach (var member in structInfo.MemberList)
                {
                    ++seq;
                    outputText += string.Format("{0})type:{1}, name:{2}   ", seq, member.Type, member.Name);
                }

                listBoxCSharpPacketProtocol.Items.Add(outputText);
                listBoxCSharpPacketProtocol.Items.Add("-----------------");
            }

            listBoxCSharpPacketProtocol.Refresh();


            foreach (var code in 생성된CSharp엔디코드)
            {
                listBoxCSharpPacketEnDecode.Items.Add(code);
            }

            listBoxCSharpPacketEnDecode.Refresh();
        }
    }
}
