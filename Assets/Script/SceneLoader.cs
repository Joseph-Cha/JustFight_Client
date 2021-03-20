using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{   
    public Animator Animator;
    private float _loadingTime = 3.0f;
    private string _mainSceneName = "Main";
    public void OnPlayGame()
    {
        Debug.Log("On Play Button");
        Animator?.SetTrigger("Start");
        StartCoroutine(LoadScene(_loadingTime));
    }

    private IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(_mainSceneName);
    }
}
