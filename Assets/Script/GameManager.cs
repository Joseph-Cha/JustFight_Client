using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public Text PlayTime;
    private TimeSpan startTime = new TimeSpan(0, 10, 0);


    private void Start()
    {
        InvokeRepeating("CountDown", 0, 1);
    }



    private void CountDown()
    {
        remainingTime = startTime - TimeSpan.FromSeconds(1);
        PlayTime.text = remainingTime.ToString(@"mm\:ss")
    }
}
