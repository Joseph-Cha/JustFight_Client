using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance ??= FindObjectOfType<GameManager>();
    private static GameManager instance;
    public GameObject Player;
    public Text PlayTime;
    public TimeSpan remainingTime { get; set; }
    private TimeSpan startTime = new TimeSpan(0, 10, 0);
    private void OnEnable()
    {
        remainingTime = startTime;
        InvokeRepeating("CountDown", 0, 1);
    }
    private void Start()
    {
        CreatePlayer();
    }
    private void CountDown()
    {
        remainingTime -= TimeSpan.FromSeconds(1);
        PlayTime.text = remainingTime.ToString(@"mm\:ss");
    }
    private void CreatePlayer()
    {
        Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
