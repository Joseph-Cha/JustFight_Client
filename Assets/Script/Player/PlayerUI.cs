using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.ComponentModel;

public class PlayerUI : MonoBehaviour
{
    public Player Player;
    public TextMeshProUGUI PlayerNameText;
    public IInputDirection InputController;
    private void Awake()
    {
        Player = new Player();
    }
    private void Start()
    {
        InitPlayerUI();
    }
    private void InitPlayerUI()
    {
        PlayerNameText.text = Player.playerName;
    }
}
