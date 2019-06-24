using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObject : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        var direction = new Vector2(
                target.position.x - transform.position.x,
                target.position.y - transform.position.y
            );

        transform.up = direction * -1;
    }
}
