using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float healthAmount;
    public float damageAmount;
    private void OnTriggerEnter2D(Collider2D PlayerCollision)
    {
        healthAmount = healthAmount - damageAmount;
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
