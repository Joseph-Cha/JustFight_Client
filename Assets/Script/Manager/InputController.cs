using MyDelegate;
using UnityEngine;

public class InputController : MonoBehaviour, IInputDirection
{
    public event InputDirectionEventHandler DirectoinInput;

    // Update is called once per frame
    void Update()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            switch(e.keyCode)
            {
                case KeyCode.RightArrow:
                DirectoinInput?.Invoke(InputInfo.Right);
                break;

                case KeyCode.LeftArrow:
                DirectoinInput?.Invoke(InputInfo.Left);
                break;

                case KeyCode.DownArrow:
                DirectoinInput?.Invoke(InputInfo.Down);
                break;

                case KeyCode.UpArrow:
                DirectoinInput?.Invoke(InputInfo.Up);
                break;  
            }
        }
    }
}
