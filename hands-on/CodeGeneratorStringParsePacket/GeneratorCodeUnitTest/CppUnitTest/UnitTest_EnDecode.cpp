#include "stdafx.h"
#include "CppUnitTest.h"
#include "SampleProtocol.h"
#include "SampleEnDecoder.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

// 유닛테스트 설명 http://codezine.jp/article/detail/6464

namespace CppUnitTest
{		
	TEST_CLASS(SampleProtocolEnDecode)
	{
	public:
		
		TEST_METHOD(Encoding1)
		{
			// [준비]
			setlocale(LC_ALL, "");

			PKTReqLogin ReqLogin1 = MakePKTReqLogin(L"Test", L"test123");
			PKTReqLogin ReqLogin2;

			// [실행]
			apedg::EnDecodePKTReqLogin EnCode;
			EnCode.Encode(ReqLogin1, 1, 1001, nullptr, 0);
						
			apedg::EnDecodePKTReqLogin Decode;
			Decode.Decode(EnCode.m_Buffer, ReqLogin2);

			// [검증]
			Assert::AreEqual(ReqLogin1.IDLength, ReqLogin2.IDLength);
			Assert::AreEqual(ReqLogin1.PWLength, ReqLogin2.PWLength);
			Assert::AreEqual(ReqLogin1.szID, ReqLogin2.szID);
			Assert::AreEqual(ReqLogin1.szPW, ReqLogin2.szPW);
		}

		TEST_METHOD(Encoding2)
		{
			// [준비]
			setlocale(LC_ALL, "");

			PKTReqLogin ReqLogin1 = MakePKTReqLogin(L"Test나나", L"테스트123");
			PKTReqLogin ReqLogin2;

			// [실행]
			apedg::EnDecodePKTReqLogin EnCode;
			EnCode.Encode(ReqLogin1, 1, 1001, nullptr, 0);

			apedg::EnDecodePKTReqLogin Decode;
			Decode.Decode(EnCode.m_Buffer, ReqLogin2);

			// [검증]
			Assert::AreEqual(ReqLogin1.IDLength, ReqLogin2.IDLength);
			Assert::AreEqual(ReqLogin1.PWLength, ReqLogin2.PWLength);
			Assert::AreEqual(ReqLogin1.szID, ReqLogin2.szID);
			Assert::AreEqual(ReqLogin1.szPW, ReqLogin2.szPW);
		}

		PKTReqLogin MakePKTReqLogin(wchar_t* pszID, wchar_t* pszPW)
		{
			PKTReqLogin ReqLogin;
			ReqLogin.IDLength = wcsnlen_s(pszID, MAX_ID_LENGTH);
			wcsncpy_s(ReqLogin.szID, MAX_ID_LENGTH, pszID, MAX_ID_LENGTH - 1);

			ReqLogin.PWLength = wcsnlen_s(pszPW, MAX_PW_LENGTH);
			wcsncpy_s(ReqLogin.szPW, MAX_PW_LENGTH, pszPW, MAX_PW_LENGTH - 1);

			return ReqLogin;
		}


		TEST_METHOD(Encoding3)
		{
			// [준비]
			setlocale(LC_ALL, "");

			PKTResCharacterInfo Response1{ 100, 11.34f };
			PKTResCharacterInfo Response2;

			// [실행]
			apedg::EnDecodePKTResCharacterInfo EnCode;
			EnCode.Encode(Response1, 1, 1001, nullptr, 0);

			apedg::EnDecodePKTResCharacterInfo Decode;
			Decode.Decode(EnCode.m_Buffer, Response2);

			// [검증]
			Assert::AreEqual(Response1.HP, Response2.HP);
			Assert::AreEqual(Response1.Exp, Response2.Exp);
		}


		TEST_METHOD(Encoding4)
		{
			// [준비]
			setlocale(LC_ALL, "");

			PKTResCharacterItemFix Response1;
			Response1.ItemCount = 2;
			Response1.ItemList[0].Index = 11;
			Response1.ItemList[0].Level = 2;
			Response1.ItemList[1].Index = 15;
			Response1.ItemList[1].Level = 3;

			PKTResCharacterItemFix Response2;

			// [실행]
			apedg::EnDecodePKTResCharacterItemFix EnCode;
			EnCode.Encode(Response1, 1, 1001, nullptr, 0);

			apedg::EnDecodePKTResCharacterItemFix Decode;
			Decode.Decode(EnCode.m_Buffer, Response2);

			// [검증]
			Assert::AreEqual(Response1.ItemCount, Response2.ItemCount);
			Assert::AreEqual(Response1.ItemList[0].Index, Response2.ItemList[0].Index);
			Assert::AreEqual(Response1.ItemList[0].Level, Response2.ItemList[0].Level);
			Assert::AreEqual(Response1.ItemList[1].Index, Response2.ItemList[1].Index);
			Assert::AreEqual(Response1.ItemList[1].Level, Response2.ItemList[1].Level);
		}

	};
}