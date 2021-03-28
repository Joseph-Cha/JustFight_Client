using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text PlayTime;
    
    private TimeSpan startTime = new TimeSpan(0, 10, 0);
    public TimeSpan remainingTime { get; set; }
    
    private void OnEnable()
    {
        remainingTime = startTime;
        InvokeRepeating("CountDown", 0, 1);
    }
    private void CountDown()
    {
        startTime -= TimeSpan.FromSeconds(1);
        remainingTime = startTime;
        PlayTime.text = remainingTime.ToString(@"mm\:ss");
    }
}
