using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage;
    public string tag;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var hitGameObject = collision.gameObject;
        if (hitGameObject.CompareTag(tag))
        {
            var health = hitGameObject.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            } 
        }
    }

}
