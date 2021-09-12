using UnityEngine;

public class Player
{
    public Vector2Int CurPosition { get; set; }
    public string playerName { get; set; }
    public Player()
    {
        InputController.Instance.DirectoinInput += UpdateDestination;
        GetPlayerData();
    }

    public void GetPlayerData()
    {
        if(PlayerPrefs.HasKey(nameof(Player.playerName)))
        {
            playerName = PlayerPrefs.GetString(nameof(Player.playerName));
        }
    }

    public void UpdateDestination(KeyCode keyCode)
    {
        Vector2Int desPosition = new Vector2Int(0, 0);
        switch (keyCode)
        {
            case KeyCode.UpArrow:
            desPosition = CurPosition + new Vector2Int(0,1);
            break;
            case KeyCode.DownArrow:
            desPosition = CurPosition + new Vector2Int(0,-1);
            break;
            case KeyCode.RightArrow:
            desPosition = CurPosition + new Vector2Int(1,0);
            break;
            case KeyCode.LeftArrow:
            desPosition = CurPosition + new Vector2Int(-1,0);
            break;
        }
        UpdatePosition(desPosition);
    }

    private void UpdatePosition(Vector2Int desPosition)
    {
        CurPosition = desPosition;
    }
}
