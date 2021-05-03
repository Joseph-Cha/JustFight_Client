using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Player player;
    public Player Player => player ??= FindObjectOfType<Player>();
    public TextMeshProUGUI PlayerNameText;
    private void Start()
    {
        InitPlayerUI();
    }
    private void InitPlayerUI()
    {
        PlayerNameText.text = Player.name;
    }

}
