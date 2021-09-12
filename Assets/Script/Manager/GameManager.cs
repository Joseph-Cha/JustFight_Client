using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance ??= FindObjectOfType<GameManager>();
    public TimeSpan remainingTime { get; set; }
    private TimeSpan startTime = new TimeSpan(0, 10, 0);
    private CountDownUI countDownUI;

    private void OnEnable()
    {
        remainingTime = startTime;
        InvokeRepeating(nameof(GameManager.CountDown), 0, 1);
    }

    private void Start()
    {
        countDownUI = FindObjectOfType<CountDownUI>();
        CreatePlayer();
    }

    private void CountDown()
    {
        countDownUI.CountDown(remainingTime);
        remainingTime -= TimeSpan.FromSeconds(1);
    }

    private void CreatePlayer()
    {
        GameObject Player = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player.prefab", typeof(GameObject));
        Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
