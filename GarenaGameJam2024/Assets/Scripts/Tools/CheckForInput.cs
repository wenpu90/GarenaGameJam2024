using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckForInput : MonoBehaviour
{
    public UnityEvent unityEvent;
    public KeyCode keycode;
    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            unityEvent.Invoke();
        }
    }
}
