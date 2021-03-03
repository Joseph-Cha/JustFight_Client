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
    1. (UI)"Touch To Start"를 터치하면 메인 씬으로 화면 전환
        - `유저` ⇒ `Button` : *화면 터치*
        - `Button` ⇒ `SceneLoader` : *OnClick() : void*
        - `SceneLoader` ⇒ `SceneLoader` : *OnStart() : void*
    2. 타이틀 아래에서 (UI)"Touch To Start"가 깜빡 거림
        - `Animator` ⇒ `Touch To Start(UI)` : *Play() : void*
    3. 화면 전환할 때 Fade In & Out
        - `SceneLoader` ⇒ `Animator` : *SetTrigger(string) : void*
        - `Animator` ⇒ `BlackView(UI)` : *Play() : void*
2. 제한 시간(10분) 카운트 다운 시작
    1. 게임 시작과 동시에 화면 상단 중앙에서 "10 : 00(UI)"가 1초씩 감소
        - `GameManager` ⇒ `GameManager` : *Start() : void*
        - `GameManager` ⇒ `RemainingTime(UI)` : *CountDown() : void*
