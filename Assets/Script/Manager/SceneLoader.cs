using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{   
    public Animator Animator;
    private float loadingTime = 3.0f;
    private string mainSceneName = "Main";
    public void OnPlayGame()
    {
        Debug.Log("On Play Button");
        Animator?.SetTrigger("Start");
        StartCoroutine(LoadScene(loadingTime));
    }

    private IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(mainSceneName);
    }
}
