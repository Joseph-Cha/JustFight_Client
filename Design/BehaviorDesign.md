### 단위별 기능들
- 앱 실행 후 인게임에 들어가기 전까지
- GM : 제한 시간(10분) 카운트 다운 시작
- 플레이어 : 생성
- 플레이어 : 이동
- 플레이어 : 공격
- 플레이어 : 무기 변경
- 몬스터 : AI 이동
- 몬스터 : 플레이어가 사정거리로 왔을 시 자동 공격
- 몬스터 : 사망
- 몬스터 : 사망시 코인 드랍 이벤트 발생,
- 플레이어 : 몬스터 사망시 코인 드랍 이벤트를 통해 코인 획득
- 플레이어 : 사망
- NPC : 플레이어와 대화
- NPC : 코인으로 무기 구매
- NPC : 도움말
- GM : 제한 시간(10분) 끝나면 PVP 맵으로 이동
- GM : 승리 조건

### 기능별 요구사항 리스트 및 설계 
- Legend
    - block : object
    - italic : message
1. 앱 실행 후 인게임에 들어가기 전까지
    1. 타이틀 아래에서 (UI)"Touch To Start"가 깜빡 거림
        - `Animator` ⇒ `Touch To Start(UI)` : *Play() : void*
    2. (UI)"Touch To Start"를 터치하면 3초 후 메인 씬으로 화면 전환
        - `유저` ⇒ `Button` : *화면 터치*
        - `Button` ⇒ `SceneLoader` : *OnClick() : void*
        - `SceneLoader` ⇒ `SceneLoader` : *OnPlayGame() : void*   
        - `SceneLoader` => `SceneManager` : *LoadScene() : void* 
    3. 화면 전환할 때 3초 동안 Fade out
        - `SceneLoader` ⇒ `Animator` : *Fadeout() : IEnumerator*
        - `Animator` ⇒ `BlackView(UI)` : *Play() : void*
2. 제한 시간(10분) 카운트 다운 시작
    1. 게임 시작과 동시에 화면 상단 중앙에서 "10 : 00(UI)"가 1초씩 감소
        - `GameManager` ⇒ `GameManager` : *Start() : void*
        - `GameManager` ⇒ `RemainingTime(UI)` : *CountDown() : void*
3. 플레이어 생성
   1. 게임 시작 전 플레이어 이름 입력 
      - `유저` ⇒ `InputField` : *입력*                     // InputField에 캐릭터 이름 입력
      - `InputField` ⇒ `StartData` : *SavePlayerData*      // InputField의 text 값을 PlayerPrefs에 저장
   2. 입력한 플레이어 이름을 머리 위에 띄우며 플레이어 생성
      - `GameManager` ⇒ `Player` : *CreatePlayer*         // 본 게임 시작되면 Player를 생성
      - `Player` ⇒ `PlayerPrefs` : *GetPlayerData*        // 인트로씬에서 저장한 Player의 데이터를 가지고 옴
      - `Player` ⇒ `Player` : *InitPlayerSetting*         // Player가 생성될 때 데이터 초기화

## 메모장
### A => B의 의미
A : 피객체(객체가 원하는 데이터를 가지고 있음)
B : 피객체의 데이터를 가지고 작업하는 객체
=> : B에서 작성된 메서드이고 B가 A를 참조한다.

### 플레이어 초기 셋팅
이름 정보 이외에 데이터(GameManager가 가지고 있는 값)들을 토대로 생성하기를 원함

### 데이터 관리
데이터를 저장하고 와서 데이터를 가지고 다양한 처리를 담당하는 매니저 => `GameManager`
플레이어의 속성 값과 속성 값을 가지고 실제 행동을 담당하는 클래스 => `Player`
