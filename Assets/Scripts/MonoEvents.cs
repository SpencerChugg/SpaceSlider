using UnityEngine;
using UnityEngine.Events;

public class MonoEvents : MonoBehaviour
{
    public UnityEvent StartEvent, TriggerEnterEvent;
    private void Start()
    {
        StartEvent.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerEnterEvent.Invoke();
    }
}