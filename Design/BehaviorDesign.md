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
- 몬스터 : 코인 드랍
- 플레이어 : 코인 획득
- 플레이어 : 사망
- NPC : 플레이어와 대화
- NPC : 코인으로 무기 구매
- NPC : 도움말
- GM : 제한 시간(10분) 끝나면 PVP 맵으로 이동
- GM : 승리 조건

### 기능별 요구사항 리스트
1. 앱 실행 후 인게임에 들어가기 전까지
    - 앱 실행 시 타이틀 화면 등장
    - 타이틀 아래에서 (UI)"Touch To Start"가 깜빡 거림
    - (UI)"Touch To Start"를 터치하면 메인 씬으로 화면 전환 
    - 화면 전환할 때 Fade In & Out

2. 제한 시간(10분) 카운트 다운 시작
    - 게임 시작과 동시에 화면 상단 중앙에서 (UI)"10 : 00"가 1초씩 감소

### 기능별 설계
1. 앱 실행 후 인게임에 들어가기 전까지
    - Scene 
        - name : TitleScene
    - UI
        - Title : TextMeshPro
        - Touch To Start : Button
    - Class 
        - SceneLoader
            - -OnStart() : void
    - Animation
        - Touch To Start : Alpha Value 0 ~ 1 
        - Fade in & out : Alpha value 0 ~ 1
2. 제한 시간(10분) 카운트 다운 시작
    - Scene
        - name : Main
    - UI
        - RemainingTime : Text
    - class
        - GameManager
            - -CountDown() : void