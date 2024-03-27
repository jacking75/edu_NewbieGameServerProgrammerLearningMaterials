#pragma once

#include "SampleProtocol.h"

#include <stdio.h>
#include <wchar.h>

 



///////////////////////////////////////////////////////////////////////////////////////
/*
코드 변화 방법이 아닌 sprintf 문을 사용하여 변환이 가능하다.그리고 꼭 setlocals 함수로 문자 코드표를 지정해야 한다.
필요한 헤더 파일 <locale.h>
사용자 컴퓨터의 OS에 따라간다면 setlocale(LC_ALL, "");

Ansi->UniCode
_snwprintf_s를 사용한다.핵심은 인자 중 유니코드는 %s를 사용하지만 Ansi인 경우는 %S를 사용한다.
_snwprintf_s(acBuffer, _countof(acBuffer), _TRUNCATE, L"[%s] %S", L"유니코드문자열", "안시코드문자열");

UniCode->Ansi
_snprintf_s를 사용한다.핵심은 인자 중 유니코드는 %S를 사용하지만 Ansi인 경우는 %s를 사용한다.
_snprintf_s(acBuffer, _countof(acBuffer), _TRUNCATE, "[%S] %s", L"유니코드문자열", "안시코드문자열");
*/

namespace apedg //AutoPacketEnDecodeGenerator
{
	struct Encoder
	{
		template<class T>
		static short WriteNumber(T Value, char* Buffer, short Pos)
		{
			short ValueSize = sizeof(T);
			memcpy(&Buffer[Pos], &Value, ValueSize);
			return ValueSize;
		}

		static short WriteWChar(wchar_t* pszText, char* pBuffer, short Pos, int BufferSize)
		{
			auto len = _snprintf_s(&pBuffer[Pos + 2], (BufferSize - (Pos + 2)), (BufferSize - (Pos + 2)) - 1, "%S", pszText);
			WriteNumber<short>((short)len, pBuffer, Pos);
			return (short)(len + 2);
		}
	};

	struct DeCoder
	{
		template<class T>
		static short ReadNumber(T* Value, char* Buffer, short Pos)
		{
			short ValueSize = sizeof(T);
			memcpy(Value, &Buffer[Pos], ValueSize);
			return ValueSize;
		}

		static short ReadWChar(wchar_t* pszText, short szSize, char* pBuffer, short Pos, char* pTempBuffer)
		{
			short ByteLength = 0;
			ReadNumber<short>(&ByteLength, pBuffer, Pos);
			memcpy(pTempBuffer, &pBuffer[Pos + 2], ByteLength);
			pTempBuffer[ByteLength] = '\0';

			_snwprintf_s(pszText, szSize, szSize - 1, L"%S", pTempBuffer);
			return (short)(ByteLength + 2);
		}
	};

	struct  EnDecodePKTReqLogin
	{
		//const int MAX_BUFFER_SIZE = 2048; // 정의 문서에 의해서 숫자가 유동적으로 되기를 바란다.
		char m_Buffer[2048];
		char m_TempBuffer[2048];
		short MaxBufferSize = 2048;

		char* Encode_Init(char* OutPutBuffer, int OutPutBufferSize)
		{
			if (OutPutBuffer != nullptr)
			{
				MaxBufferSize = OutPutBufferSize;
				return OutPutBuffer;
			}

			return m_Buffer;
		}


		bool Encode(PKTReqLogin& PacketData, short RegionID, short PacketID, char* OutPutBuffer, int OutPutBufferSize)
		{
			short UseSize = 0;
			short WritePos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작
			char* pBuffer = Encode_Init(OutPutBuffer, OutPutBufferSize);
			memset(pBuffer, 0, MaxBufferSize);

			UseSize = Encoder::WriteNumber<short>(PacketData.IDLength, pBuffer, WritePos);
			WritePos += UseSize;

			UseSize = Encoder::WriteWChar(PacketData.szID, pBuffer, WritePos, MaxBufferSize);
			WritePos += UseSize;

			UseSize = Encoder::WriteNumber<short>(PacketData.PWLength, pBuffer, WritePos);
			WritePos += UseSize;

			UseSize = Encoder::WriteWChar(PacketData.szPW, pBuffer, WritePos, MaxBufferSize);
			WritePos += UseSize;


			short BodySize = WritePos - HEADER_SIZE;
			Encoder::WriteNumber<short>(RegionID, pBuffer, 0);
			Encoder::WriteNumber<short>(PacketID, pBuffer, 2);
			Encoder::WriteNumber<short>(BodySize, pBuffer, 4);

			return true;
		}

		bool Decode(char* pBuffer, PKTReqLogin& PacketData)
		{
			short UseSize = 0;
			short ReadPos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작

			UseSize = DeCoder::ReadNumber<short>(&PacketData.IDLength, pBuffer, ReadPos);
			ReadPos += UseSize;

			UseSize = DeCoder::ReadWChar(PacketData.szID, MAX_ID_LENGTH, pBuffer, ReadPos, m_TempBuffer);
			ReadPos += UseSize;

			UseSize = DeCoder::ReadNumber<short>(&PacketData.PWLength, pBuffer, ReadPos);
			ReadPos += UseSize;

			UseSize = DeCoder::ReadWChar(PacketData.szPW, MAX_PW_LENGTH, pBuffer, ReadPos, m_TempBuffer);
			ReadPos += UseSize;
			return true;
		}
	};


	struct  EnDecodePKTResCharacterInfo
	{
		char m_Buffer[2048];
		char m_TempBuffer[2048];
		short MaxBufferSize = 2048;

		char* Encode_Init(char* OutPutBuffer, int OutPutBufferSize)
		{
			if (OutPutBuffer != nullptr)
			{
				MaxBufferSize = OutPutBufferSize;
				return OutPutBuffer;
			}

			return m_Buffer;
		}


		bool Encode(PKTResCharacterInfo& PacketData, short RegionID, short PacketID, char* OutPutBuffer, int OutPutBufferSize)
		{
			short UseSize = 0;
			short WritePos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작
			char* pBuffer = Encode_Init(OutPutBuffer, OutPutBufferSize);
			memset(pBuffer, 0, MaxBufferSize);

			UseSize = Encoder::WriteNumber<int>(PacketData.HP, pBuffer, WritePos);
			WritePos += UseSize;

			UseSize = Encoder::WriteNumber<float>(PacketData.Exp, pBuffer, WritePos);
			WritePos += UseSize;


			short BodySize = WritePos - HEADER_SIZE;
			Encoder::WriteNumber<short>(RegionID, pBuffer, 0);
			Encoder::WriteNumber<short>(PacketID, pBuffer, 2);
			Encoder::WriteNumber<short>(BodySize, pBuffer, 4);

			return true;
		}

		bool Decode(char* pBuffer, PKTResCharacterInfo& PacketData)
		{
			short UseSize = 0;
			short ReadPos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작

			UseSize = DeCoder::ReadNumber<int>(&PacketData.HP, pBuffer, ReadPos);
			ReadPos += UseSize;

			UseSize = DeCoder::ReadNumber<float>(&PacketData.Exp, pBuffer, ReadPos);
			ReadPos += UseSize;

			return true;
		}
	};

	struct  EnDecodePKTResCharacterItemFix
	{
		char m_Buffer[2048];
		char m_TempBuffer[2048];
		short MaxBufferSize = 2048;

		char* Encode_Init(char* OutPutBuffer, int OutPutBufferSize)
		{
			if (OutPutBuffer != nullptr)
			{
				MaxBufferSize = OutPutBufferSize;
				return OutPutBuffer;
			}

			return m_Buffer;
		}


		bool Encode(PKTResCharacterItemFix& PacketData, short RegionID, short PacketID, char* OutPutBuffer, int OutPutBufferSize)
		{
			short UseSize = 0;
			short WritePos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작
			char* pBuffer = Encode_Init(OutPutBuffer, OutPutBufferSize);
			memset(pBuffer, 0, MaxBufferSize);

			UseSize = Encoder::WriteNumber<short>(PacketData.ItemCount, pBuffer, WritePos);
			WritePos += UseSize;

			for (int i = 0; i < PacketData.ItemCount; ++i)
			{
				UseSize = Encoder::WriteNumber<unsigned __int64>(PacketData.ItemList[i].Index, pBuffer, WritePos);
				WritePos += UseSize;

				UseSize = Encoder::WriteNumber<short>(PacketData.ItemList[i].Level, pBuffer, WritePos);
				WritePos += UseSize;
			}


			short BodySize = WritePos - HEADER_SIZE;
			Encoder::WriteNumber<short>(RegionID, pBuffer, 0);
			Encoder::WriteNumber<short>(PacketID, pBuffer, 2);
			Encoder::WriteNumber<short>(BodySize, pBuffer, 4);

			return true;
		}

		bool Decode(char* pBuffer, PKTResCharacterItemFix& PacketData)
		{
			short UseSize = 0;
			short ReadPos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작

			UseSize = DeCoder::ReadNumber<short>(&PacketData.ItemCount, pBuffer, ReadPos);
			ReadPos += UseSize;

			for (int i = 0; i < PacketData.ItemCount; ++i)
			{
				UseSize = DeCoder::ReadNumber<unsigned __int64>(&PacketData.ItemList[i].Index, pBuffer, ReadPos);
				ReadPos += UseSize;

				UseSize = DeCoder::ReadNumber<short>(&PacketData.ItemList[i].Level, pBuffer, ReadPos);
				ReadPos += UseSize;
			}

			return true;
		}
	};


	struct  EnDecodePKTResTest1
	{
		char m_Buffer[2048];
		char m_TempBuffer[2048];
		short MaxBufferSize = 2048;

		char* Encode_Init(char* OutPutBuffer, int OutPutBufferSize)
		{
			if (OutPutBuffer != nullptr)
			{
				MaxBufferSize = OutPutBufferSize;
				return OutPutBuffer;
			}

			return m_Buffer;
		}


		bool Encode(PKTResTest1& PacketData, short RegionID, short PacketID, char* OutPutBuffer, int OutPutBufferSize)
		{
			short UseSize = 0;
			short WritePos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작
			char* pBuffer = Encode_Init(OutPutBuffer, OutPutBufferSize);
			memset(pBuffer, 0, MaxBufferSize);

			for (int i = 0; i < MAX_LOAD_TEST1_COUNT; ++i)
			{
				UseSize = Encoder::WriteNumber<int>(PacketData.Tests[i], pBuffer, WritePos);
				WritePos += UseSize;
			}


			short BodySize = WritePos - HEADER_SIZE;
			Encoder::WriteNumber<short>(RegionID, pBuffer, 0);
			Encoder::WriteNumber<short>(PacketID, pBuffer, 2);
			Encoder::WriteNumber<short>(BodySize, pBuffer, 4);

			return true;
		}

		bool Decode(char* pBuffer, PKTResCharacterItemFix& PacketData)
		{
			short UseSize = 0;
			short ReadPos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작

			for (int i = 0; i < MAX_LOAD_TEST1_COUNT; ++i)
			{
				UseSize = DeCoder::ReadNumber<int>(&PacketData.Tests[i], pBuffer, ReadPos);
				ReadPos += UseSize;
			}

			return true;
		}
	};


	struct  EnDecodePKTResTest2
	{
		char m_Buffer[2048];
		char m_TempBuffer[2048];
		short MaxBufferSize = 2048;

		char* Encode_Init(char* OutPutBuffer, int OutPutBufferSize)
		{
			if (OutPutBuffer != nullptr)
			{
				MaxBufferSize = OutPutBufferSize;
				return OutPutBuffer;
			}

			return m_Buffer;
		}


		bool Encode(PKTResTest2& PacketData, short RegionID, short PacketID, char* OutPutBuffer, int OutPutBufferSize)
		{
			short UseSize = 0;
			short WritePos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작
			char* pBuffer = Encode_Init(OutPutBuffer, OutPutBufferSize);
			memset(pBuffer, 0, MaxBufferSize);

			UseSize = Encoder::WriteNumber<short>(PacketData.TestCount, pBuffer, WritePos);
			WritePos += UseSize;

			for (int i = 0; i < PacketData.TestCount; ++i)
			{
				UseSize = Encoder::WriteNumber<short>(PacketData.Tests[i], pBuffer, WritePos);
				WritePos += UseSize;
			}


			short BodySize = WritePos - HEADER_SIZE;
			Encoder::WriteNumber<short>(RegionID, pBuffer, 0);
			Encoder::WriteNumber<short>(PacketID, pBuffer, 2);
			Encoder::WriteNumber<short>(BodySize, pBuffer, 4);

			return true;
		}

		bool Decode(char* pBuffer, PKTResTest2& PacketData)
		{
			short UseSize = 0;
			short ReadPos = HEADER_SIZE; // 헤더 부분 이후부터 인코딩 시작

			UseSize = DeCoder::ReadNumber<short>(&PacketData.TestCount, pBuffer, ReadPos);
			ReadPos += UseSize;

			for (int i = 0; i < PacketData.TestCount; ++i)
			{
				UseSize = DeCoder::ReadNumber<short>(&PacketData.Tests[i], pBuffer, ReadPos);
				ReadPos += UseSize;
			}

			return true;
		}
	};
}