using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public string Name { get; set; }
    private void Awake()
    {
        GetPlayerData();
    }
    private void GetPlayerData()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            Name = PlayerPrefs.GetString("Name");
        }
    }
}
