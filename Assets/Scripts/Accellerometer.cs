using UnityEngine;
using System.Collections;

public class Accellerometer : MonoBehaviour
{
    public FloatSO Speed;
    void Update()
    {
        transform.Translate(Input.acceleration.x * Time.deltaTime * Speed.Value, 0, 0);
    }
}