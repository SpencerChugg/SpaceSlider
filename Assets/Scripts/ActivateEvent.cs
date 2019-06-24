using System;
using UnityEngine;
using UnityEngine.Events;

public class ActivateEvent : MonoBehaviour
{
    public UnityEvent ActiveEvent;
    public GameObject EventObj;
    void Update()
    {
       if (EventObj != isActiveAndEnabled)
        {
            ActiveEvent.Invoke();
        }
    }
}
