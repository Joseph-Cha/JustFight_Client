using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float playingTime { get; set; } = 600f;
    public float remainTime { get; set; } = 0;
    public float elapsedTime { get; set; }
    public Text Minutes;
    public Text Seconds;

    private void Start()
    {
        Minutes.text = (playingTime/60).ToString();
        Seconds.text = "00";

    }

    private void Update()
    {
        // 나중에 남은 시간이 얼마인지가 필요함 => 게임 종료 시간 파악
        // UI에 띄울 것은 분과 초
        // 우선 초를 깎고(59초) 0초가 되면 다시 
        // 남은 시간 = 현재 시간 - 지난 시간
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 60)
            elapsedTime = 0;
        remainTime = 60 - elapsedTime;
        //Minutes.text = (remainTime/60).ToString();
        // Seconds.text = 
        Debug.Log((int)remainTime);
    }

    private void CountDown()
    {

    }

    

}
