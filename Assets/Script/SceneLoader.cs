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
        StartButton.onClick.AddListener(delegate {OnStart();});
    }
    
    void OnStart()
    {
        Animator.SetTrigger("Start");
        SceneManager.LoadScene("Main");
    }


}
