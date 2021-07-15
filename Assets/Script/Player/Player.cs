using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public IInputDirection InputDirection;
    public Vector2Int Position { get; set; }
    public string Name { get; set; }
    private void Awake()
    {
        InputDirection.DirectoinInput += UpdateDestination;
        GetPlayerData();
    }

    public void GetPlayerData()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            Name = PlayerPrefs.GetString("Name");
        }
    }

    public void UpdateDestination(InputInfo inf)
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        
    }
}
