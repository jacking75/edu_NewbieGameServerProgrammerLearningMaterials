#include "stdafx.h"
#include "CppUnitTest.h"

#include "..\NativeLib\Calculator.h"


using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(TestMethod1)
		{
			Calculator cal;
			Assert::AreEqual(3, cal.Add(1, 2));
		}

	};
}