using UnityEngine;
using System.Collections;

public class Accellerometer : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.acceleration.x * Time.deltaTime * 10, 0, 0);
    }
}