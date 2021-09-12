using UnityEngine;
using System;
using UnityEditor;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance ??= FindObjectOfType<GameManager>();
    public TimeSpan remainingTime { get; set; }
    public Action<TimeSpan> CountDown;
    private TimeSpan startTime = new TimeSpan(0, 10, 0);
    private TimeSpan endTime = new TimeSpan(0, 0, 0);
    private float interval { get; } = 1f;

    private void OnEnable()
    {
        remainingTime = startTime;
    }

    private void Start()
    {
        CreatePlayer();
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        while(remainingTime > endTime)
        {
            CountDown?.Invoke(remainingTime);
            remainingTime -= TimeSpan.FromSeconds(interval);
            yield return new WaitForSeconds(interval);
        }
    }

    private void CreatePlayer()
    {
        GameObject Player = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player.prefab", typeof(GameObject));
        Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
