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

namespace PacketEnDeCodeGeneratorWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var 인코딩디코딩코드_생성기 = new CodeGenerator();

            Int16 maxBufferSize = Convert.ToInt16(textBoxMaxBufferSize.Text);
            string packetDataNamePrefix = "PKT";
            
            var fileLoadingResult = 인코딩디코딩코드_생성기.CppParse.ParseFile(textBoxCppSourceFileFullPath.Text, maxBufferSize, packetDataNamePrefix);
            if (fileLoadingResult != ERROR_CODE.NONE)
            {
                MessageBox.Show(string.Format("패킷 데이터 구조체 파싱 실패. {0}", fileLoadingResult.ToString()));
                return;
            }


            // C++ 엔코딩/디코딩 소스
            var result = 인코딩디코딩코드_생성기.CppPacketEnDecode.Generate(textBoxGenerateCppFileNamespace.Text, 인코딩디코딩코드_생성기.CppParse.FileName, 인코딩디코딩코드_생성기.CppParse.구조체정의_사전);
            if (result != ERROR_CODE.NONE)
            {
                MessageBox.Show(string.Format("C++ 프로토콜 인코딩/디코딩 코드 생성 실패. {0}", result.ToString()));
                return;
            }

            인코딩디코딩코드_생성기.WriteFile(textBoxGenerateCppFileFullPath.Text, 인코딩디코딩코드_생성기.CppPacketEnDecode.FullSourceCode);
            
            
            // C# 프로토콜 소스
            result = 인코딩디코딩코드_생성기.CSharpPacketData.GenerateCode(textBoxGenerateCSharpPacketFileNamespace.Text, 인코딩디코딩코드_생성기.CppParse.구조체정의_사전, 인코딩디코딩코드_생성기.CppParse.상수정의_사전);

            if (result != ERROR_CODE.NONE)
            {
                MessageBox.Show(string.Format("C# 프로토콜 코드 생성 실패. {0}", result.ToString()));
                return;
            }

            인코딩디코딩코드_생성기.WriteFile(textBoxGenerateCSharpPacketFileFullPath.Text, 인코딩디코딩코드_생성기.CSharpPacketData.GeneratedCode);


            // C# 프로토콜 인코딩/디코딩 소스
            result = 인코딩디코딩코드_생성기.CSharpPacketEnDecode.Generate(textBoxGenerateCSharpEnDecodeFileNamespace.Text, 인코딩디코딩코드_생성기.CppParse.구조체정의_사전);

            if (result != ERROR_CODE.NONE)
            {
                MessageBox.Show(string.Format("C# 프로토콜 인코딩/디코딩 코드 생성 실패. {0}", result.ToString()));
                return;
            }

            인코딩디코딩코드_생성기.WriteFile(textBoxGenerateCSharpEnDecodeFileFullPath.Text, 인코딩디코딩코드_생성기.CSharpPacketEnDecode.FullSourceCode);


            string completeMessage = "";
            completeMessage += string.Format("{0} 위치에 'C++ 프로토콜 인코딩/디코딩 코드' 파일 생성 완료\r\n", textBoxGenerateCppFileFullPath.Text);
            completeMessage += string.Format("{0} 위치에 'C# 프로토콜 코드' 파일 생성 완료\r\n", textBoxGenerateCSharpPacketFileFullPath.Text);
            completeMessage += string.Format("{0} 위치에 'C# 프로토콜 인코딩/디코딩 코드' 파일 생성 완료\r\n", textBoxGenerateCSharpEnDecodeFileFullPath.Text);
            MessageBox.Show(completeMessage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //C#용 바이너리 파일 쓰고/읽기
        }
    }
}
