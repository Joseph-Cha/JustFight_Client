using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text PlayTime;

    private float playingTime = 600f;
    private int remainMinute;
    private int remainSeconds;


    private void Awake()
    {
        remainMinute = (int)(playingTime / 60);
        remainSeconds = (int)(playingTime % 60);
    }

    private void Start()
    {
        PlayTime.text = $"{remainMinute} : {remainSeconds}";
    }

    private void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        playingTime -= Time.deltaTime;
        remainMinute = (int)(playingTime / 60);
        remainSeconds = (int)(playingTime % 60);


        PlayTime.text = $"{remainMinute} : {remainSeconds}";
    }

    

}
