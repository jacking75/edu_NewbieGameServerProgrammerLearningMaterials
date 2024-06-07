# monogame

게임 서버 개발을 할 때 클라이언트 개발이 필요하다.  
클라이언트를 개발해서 서버와 연동하지 않으면 서버가 제대로 동작하는지 알기 어렵다.  
보통 게임 클라이언트를 개발한다면 Unity가 최우선 순위이다. 그러나 Unity는 회사에서는 사용이 어렵고, 사용하려면 개발 머신 스펙이 좋아야한다.  
간단한 형태의 게임 클라이언트를 만든다면 `monogame` 프레임워크 사용을 추천한다.  
monogame은 C#으로 프로그래밍하고, 크로스 플랫폼을 지원한다.  
  
[monogame 공식사이트](https://monogame.net/ )    
[MonoGame.Samples](https://github.com/MonoGame/MonoGame.Samples )  
[CartBlanche/MonoGame-Samples](https://github.com/CartBlanche/MonoGame-Samples )  
[(일어)MonoGame 샘플들](https://motoyamablog.blogspot.com/2017/08/monogame-samples.html )  
      	
[무료 게임 개발 라이브러리(Monogame, 구: XNA)을 설치하는 방법을 설치하는 방법](https://nowonbun.tistory.com/229 )    
- 모노게임 설명 
    - [시작하기](https://digiconfactory.tistory.com/entry/monogame-%EC%8B%9C%EC%9E%91%ED%95%98%EA%B8%B0 )    
	- [이미지 로드하기](https://digiconfactory.tistory.com/entry/%EC%9D%B4%EB%AF%B8%EC%A7%80-%EB%A1%9C%EB%93%9C%ED%95%98%EA%B8%B0-monogame )  
    - [스프라이트 조작하기](https://digiconfactory.tistory.com/entry/%EC%8A%A4%ED%94%84%EB%9D%BC%EC%9D%B4%ED%8A%B8-%EC%A1%B0%EC%9E%91-monogame )
	- [스크린에 문자열 그리기 (DrawString) / DebugView 사용하기](https://digiconfactory.tistory.com/entry/%EC%8A%A4%ED%81%AC%EB%A6%B0%EC%97%90-%EB%AC%B8%EC%9E%90%EC%97%B4-%EA%B7%B8%EB%A6%AC%EA%B8%B0-monogame )   
	- [스프라이트 클래스 만들기](https://digiconfactory.tistory.com/entry/%EC%8A%A4%ED%94%84%EB%9D%BC%EC%9D%B4%ED%8A%B8-%ED%81%B4%EB%9E%98%EC%8A%A4-monogame )
	- [사각형 그리기](https://digiconfactory.tistory.com/entry/%EC%82%AC%EA%B0%81%ED%98%95-%EA%B7%B8%EB%A6%AC%EA%B8%B0-monogame )
 
- [MonoGame - How to Use Sprite Sheets](https://industrian.net/tutorials/using-sprite-sheets/ )
 
	
# 시작  
- 설치: https://docs.monogame.net/articles/getting_started/index.html 
    - Windows, macOS, Linux 별로 설치 방법을 설명한다.
	- Windows에서 Visual Studio의 경우 [여기에서](https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_windows.html ) 
- [Windows + Visual Studio 에서 새 프로젝트 만들기](https://docs.monogame.net/articles/getting_started/2_creating_a_new_project_vs.html )
  
  
## Understanding the Code
[출처](https://docs.monogame.net/articles/getting_started/3_understanding_the_code.html )    
  
모든 모노게임 프로젝트의 핵심인 `Game.cs` 클래스 파일에는 게임 실행에 필요한 몇 가지 중요한 섹션이 있다:  
- Using statements - MonoGame의 다양한 컴포넌트에 쉽게 액세스할 수 있다.
- Game 클래스 정의 - 모든 MonoGame 프로젝트의 핵심이다.
- Game 생성자 및 주요 변수 - 프로젝트 시작 방법을 알려주는 변수이다.
- Initialize 메서드 - 게임 시작 시 게임을 초기화한다.
- 콘텐츠 로드 및 언로드 메서드 - 실행 중인 게임의 에셋을 콘텐츠 프로젝트에서 추가 및 제거하는 데 사용된다.
- Update 메서드 - 플레이어 입력을 받거나 배를 이동하거나 엔티티를 애니메이션하는 등 게임 상태를 업데이트하기 위해 정기적으로 호출되는 메서드이다.
- Draw 메서드 - 현재 게임 상태를 가져와 게임 엔티티를 화면에 그리기 위해 일정한 간격으로 호출된다.
  
  
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   