using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public Transform WarpTo;
    public Transform Current;
    private void OnTriggerEnter2D(Collider2D WarpCollision) 
    {
        Current.position = WarpTo.position;
    }
}