using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public IInputDirection InputDirection;
    public Vector2Int CurPosition { get; set; }
    public string playerName { get; set; }
    private void Awake()
    {
        InputDirection.DirectoinInput += UpdateDestination;
        GetPlayerData();
    }

    public void GetPlayerData()
    {
        if(PlayerPrefs.HasKey(nameof(Player.playerName)))
        {
            playerName = PlayerPrefs.GetString(nameof(Player.playerName));
        }
    }

    public void UpdateDestination(InputInfo info)
    {
        Vector2Int desPosition = CurPosition;
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        
    }
}
