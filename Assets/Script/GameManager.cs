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
        startTime = startTime.Subtract(new TimeSpan(0, 0, 1));
        PlayTime.text = $"{startTime.Minutes.ToString()} : {startTime.Seconds.ToString()}";
    }
}
