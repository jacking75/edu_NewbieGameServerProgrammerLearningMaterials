using PacketBinaryEnCodingGenerator;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (args.Count() != 9)
            {
                Console.WriteLine("입력 인자가 부족합니다");

                Console.WriteLine("프로토콜 파일 full path");
                Console.WriteLine("생성될 C++ 프로토콜 full path");
                Console.WriteLine("엔코드/디코드 최대 버퍼 크기");
                Console.WriteLine("패킷 데이터 구조체 프리픽스");
                Console.WriteLine("생성될 C++ 프로토콜 인코딩/디코딩 파일의 네임스페이스");
                Console.WriteLine("생성될 C# 프로토콜 파일 full path");
                Console.WriteLine("생성될 C# 프로토콜 파일의 네임스페이스");
                Console.WriteLine("생성될 C# 프로토콜 인코딩/디코딩 파일 full path");
                Console.WriteLine("생성될 C# 프로토콜 인코딩/디코딩 파일의 네임스페이스");
                return;
            }

            var 인코딩디코딩코드_생성기 = new CodeGenerator();

            Int16 maxBufferSize = Convert.ToInt16(args[2]);
            string packetDataNamePrefix = args[3];

            var fileLoadingResult = 인코딩디코딩코드_생성기.CppParse.ParseFile(args[0], maxBufferSize, packetDataNamePrefix);
            if (fileLoadingResult != ERROR_CODE.NONE)
            {
                Console.WriteLine(string.Format("패킷 데이터 구조체 파싱 실패. {0}", fileLoadingResult.ToString()));
                return;
            }


            // C++ 엔코딩/디코딩 소스
            var result = 인코딩디코딩코드_생성기.CppPacketEnDecode.Generate(args[4], 인코딩디코딩코드_생성기.CppParse.FileName, 인코딩디코딩코드_생성기.CppParse.구조체정의_사전);
            if (result != ERROR_CODE.NONE)
            {
                Console.WriteLine(string.Format("패킷 데이터 인코딩/디코딩 코드 생성 실패. {0}", result.ToString()));
                return;
            }

            인코딩디코딩코드_생성기.WriteFile(args[1], 인코딩디코딩코드_생성기.CppPacketEnDecode.FullSourceCode);

            Console.WriteLine(string.Format("{0} 위치에 'Cpp 패킷 데이터 인코딩/디코딩 코드' 파일 생성 완료", args[1]));


            // C# 프로토콜 소스
            result = 인코딩디코딩코드_생성기.CSharpPacketData.GenerateCode(args[6], 인코딩디코딩코드_생성기.CppParse.구조체정의_사전, 인코딩디코딩코드_생성기.CppParse.상수정의_사전);

            if (result != ERROR_CODE.NONE)
            {
                Console.WriteLine(string.Format("C# 프로토콜 코드 생성 실패. {0}", result.ToString()));
                return;
            }

            인코딩디코딩코드_생성기.WriteFile(args[5], 인코딩디코딩코드_생성기.CSharpPacketData.GeneratedCode);
            Console.WriteLine(string.Format("{0} 위치에 'C# 프로토콜 코드' 파일 생성 완료", args[5]));


            // C# 프로토콜 인코딩/디코딩 소스
            result = 인코딩디코딩코드_생성기.CSharpPacketEnDecode.Generate(args[8], 인코딩디코딩코드_생성기.CppParse.구조체정의_사전);

            if (result != ERROR_CODE.NONE)
            {
                Console.WriteLine(string.Format("C# 프로토콜 인코딩/디코딩 코드 생성 실패. {0}", result.ToString()));
                return;
            }

            인코딩디코딩코드_생성기.WriteFile(args[7], 인코딩디코딩코드_생성기.CSharpPacketEnDecode.FullSourceCode);
            Console.WriteLine(string.Format("{0} 위치에 'C# 프로토콜 인코딩/디코딩 코드' 파일 생성 완료", args[7]));
        }
    }
}
