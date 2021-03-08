using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Button StartButton;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(delegate {OnPlayGame();});
    }
    
    void OnPlayGame()
    {
        Animator.SetTrigger("Start");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }
}
