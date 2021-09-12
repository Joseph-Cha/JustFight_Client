using MyDelegate;
using UnityEngine;

public class InputController : MonoBehaviour, IInputDirection
{
    private static InputController instance;
    public static InputController Instance => instance ??= FindObjectOfType<InputController>();
    public event InputDirectionEventHandler DirectoinInput;
    private Event e = new Event();
    // Update is called once per frame
    void OnGUI()
    {
        e = Event.current;
        if (e != null)
        {
            if (e.isKey)
            {
                Debug.Log($"Input KeyType : {e.keyCode}");
                DirectoinInput?.Invoke(e.keyCode);
            }
        }
    }
}
