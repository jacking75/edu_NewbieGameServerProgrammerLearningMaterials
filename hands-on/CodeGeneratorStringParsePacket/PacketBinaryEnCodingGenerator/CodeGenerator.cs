using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketBinaryEnCodingGenerator;

//TODO: 데이터 줄이기
//TODO: 특정 크기 이후부터 인코딩마다 버퍼를 넘어서는지 조사한다.

// 유저 입력: 
// 패킷 구조체 정의 파일 경로(이름 포함), 
// 생성 파일 이름과 위치 
// 패킷 구조체 데이터 기본 크기,
// 패킷 구조체 데이터 최대 크기
// 패킷 엔코드/디코드를 만들 구조체의 시작패턴. 입력 안하면 "PKT"로 시작
public class CodeGenerator
{
    public CppPacketProtocolFileParse CppParse = new CppPacketProtocolFileParse();
    public GenerateCppEnDecoder CppPacketEnDecode = new GenerateCppEnDecoder();
    public GenerateCSharpPacketProtocolFile CSharpPacketData = new GenerateCSharpPacketProtocolFile();
    public GenerateCSharpEnDecoder CSharpPacketEnDecode = new GenerateCSharpEnDecoder();
    public CSharpPacketProtocolFileParse CSharpParse = new CSharpPacketProtocolFileParse();


    public void WriteFile(string fileFullPath, List<string> inputData)
    {
        var sw = new System.IO.StreamWriter(fileFullPath, false, Encoding.UTF8);

        foreach (var text in inputData)
        {
            // 줄 넘김을 하려면 \r\n이 들어가 있어야 한다.  
            sw.Write(text + Environment.NewLine);
        }
        
        sw.Close();
    }
}


public enum ERROR_CODE : short
{
    NONE    = 0,

    ERROR_FILE_EXISTS = 101,

    STRUCT_PARSE_STRUCT_TOKEN_COUNT_LESS    = 111,
    STRUCT_PARSE_STRUCT_DO_NOT_FIND         = 112,

    PACKET_HEADER_SIZE_DO_NOT_FIND          = 121,

    ERROR_TEMPLETE_FILE_EXISTS              = 201,


    CLASS_PARSE_STRUCT_TOKEN_COUNT_LESS     = 311,
}

public class MemberDataInfo
{
    public string Type;
    public string Name;
    public string ArrayDefineName;
    public int ArrayValue;
}

public class StructInfo
{
    public bool IsPassEnDecodeGenerate;
    public string Name;
    public int DefineDataBufferSize;
    public List<MemberDataInfo> MemberList = new List<MemberDataInfo>();
}

