using System.Collections;
using UnityEngine;

public class PoolObjDeactivate : MonoBehaviour
{
    [SerializeField] private float time = 3f;
    Coroutine coroutine;

    void OnEnable()
    {
        coroutine = StartCoroutine(WaitToDeactivate());
    }

    IEnumerator WaitToDeactivate()
    {
        yield return new WaitForSeconds(time);
        Deactivate();
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        StopCoroutine(coroutine);
        coroutine = null;
    }
}
