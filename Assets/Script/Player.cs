using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public TextMeshProUGUI PlayerNameText;
    public string Name { get; set; }
    private void Awake()
    {
        GetPlayerData();
    }
    private void Start()
    {
        InitPlayerSetting();
    }
    // Start is called before the first frame update
    private void InitPlayerSetting()
    {
        PlayerNameText.text = Name;
    }
    private void GetPlayerData()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            Name = PlayerPrefs.GetString("Name");
        }
    }
}
