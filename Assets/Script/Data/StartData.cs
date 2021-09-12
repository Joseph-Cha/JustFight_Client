﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StartData : MonoBehaviour
{
    public TMP_InputField PlayerName;
    public void SavePlayerData()
    {
        PlayerPrefs.SetString(nameof(Player.playerName), PlayerName.text);
    }
}
