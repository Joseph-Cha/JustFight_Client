using UnityEngine;
using System;

public interface IInputDirection
{
    event Action<KeyCode> DirectoinInput; 
}
