using System;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour, IInputDirection
{
    private static InputController instance;
    public static InputController Instance => instance ??= FindObjectOfType<InputController>();
    public event Action<KeyCode> DirectoinInput;
    
    private List<KeyCode> validKeyCodes = new List<KeyCode>()
    {
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow
    };

    void OnGUI()
    {
        Event e = Event.current;
        if (e != null)
        {
            if (e.isKey)
            {
                if (validKeyCodes.Contains(e.keyCode))
                {
                    Debug.Log($"Input KeyType : {e.keyCode}");
                    DirectoinInput?.Invoke(e.keyCode);
                }
            }
        }
    }
}
