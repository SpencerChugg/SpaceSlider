using UnityEngine;
using UnityEngine.Events;

public class PStatUpdate : MonoBehaviour
{
public UnityEvent StatUpdate;
private void Update()

    {
        StatUpdate.Invoke();
    }

}

