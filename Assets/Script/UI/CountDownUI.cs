using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    private TextMeshProUGUI countDownText;

    private void Awake()
    {
        countDownText = GetComponent<TextMeshProUGUI>();
    }

    public void CountDown(TimeSpan remainingTime)
    {
        if (countDownText != null)
            countDownText.text = remainingTime.ToString(@"mm\:ss");
    }
}