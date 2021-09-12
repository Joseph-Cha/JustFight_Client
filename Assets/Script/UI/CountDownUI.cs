using System;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    private TextMeshProUGUI countDownText;

    private void Awake()
    {
        countDownText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.CountDown += CountDown;
    }

    public void CountDown(TimeSpan remainingTime)
    {
        if (countDownText != null)
            countDownText.text = remainingTime.ToString(@"mm\:ss");
    }
}