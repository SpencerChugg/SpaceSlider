using UnityEngine;
using UnityEngine.Events;

public class OnTouchEvent : MonoBehaviour
{
    public UnityEvent OnTouch;
    private void Update()
    {
        if (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnTouch.Invoke();
        }       
    }
}


