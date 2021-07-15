using System.Collections;
using System.Collections.Generic;
using MyDelegate;
using UnityEngine;

public class InputController : MonoBehaviour, IInputDirection
{
    public event InputDirectionEventHandler DirectoinInput;

    // Update is called once per frame
    void Update()
    {
        
    }
}
