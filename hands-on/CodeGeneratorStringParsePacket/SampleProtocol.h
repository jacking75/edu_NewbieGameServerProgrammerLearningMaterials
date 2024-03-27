#pragma once

#define DEFINE_DATA_BUFFER_SIZE(ByteSize)

#include <vector>



// 지켜야 할 것 
// 1. 주석은 꼭 첫 줄에서 // 로 시작한다. /* */ 주석은 사용 불가!!!
// 2. 패킷 엔코드/디코드 코드를 만들 구조체는 꼭 PKT로 시작해야 한다.
// 3. MBCS 문자열 복사는 배열 복사 방식 사용하기. 문자열 복사는 유니코드만 지원!
// 4. 패킷 구조체에서 배열 변수 바로 위에 배열 변수의 크기를 저장하는 변수가 있어야 한다.


// 상수
const int PACKET_HEADER_SIZE = 6; // 패킷 헤더 크기 

const int MAX_ID_LENGTH = 17;
const int MAX_PW_LENGTH = 17;


struct Header {
	// 지역 ID
	short RegionID;		// short 이후 공백
	short	PacketID;	// short 이후 탭
	short	BodySize;	// short 이후 공백 탭
};


struct PKTReqLogin {
	short IDLength;
	wchar_t szID[MAX_ID_LENGTH];
	short PWLength;
	wchar_t szPW[MAX_PW_LENGTH];
};

struct PKTResLogin {
	short nResult;
	__int64 UserIndex;
};

struct PKTReqCharacterInfo {
	int CharacterIndex;
};

struct PKTResCharacterInfo {
	int HP;
	float Exp;
};


// 
struct PKTReqTest1 {
	__int64 CharCode;
};

const int MAX_LOAD_TEST1_COUNT = 24;
struct PKTResTest1 {
	__int64 CharCode;
	int Tests[MAX_LOAD_TEST1_COUNT];
};


 
struct PKTReqTest2 {
	__int64 CharCode;
};

const int MAX_LOAD_TEST2_COUNT = 24;
struct PKTResTest2 {
	short TestCount;
	short Tests[MAX_LOAD_TEST2_COUNT];
};


// 캐릭터의 완료한 퀘스트 코드 로딩 요청
struct PKTReqCompetedQuestCode {
	__int64 CharCode;
};

const int MAX_LOAD_QUEST_CODE_COUNT = 128;
struct PKTResCompetedQuestCode {
	__int64 CharCode;
	short QuestCodeCount;
	short QuestCodes[MAX_LOAD_QUEST_CODE_COUNT];
};


struct PKTReqCharacterItem {
	int CharacterIndex;
};

struct CharItem {
	unsigned __int64 Index;
	short Level;
};

struct PKTResCharacterItem {
	__int64 CharCode;
	CharItem Item;
};

const int MAX_CHARACTER_ITEM_COUNT = 32;
struct PKTResCharacterItemArray {
	short ItemCount;
	CharItem Items[MAX_CHARACTER_ITEM_COUNT];
};

