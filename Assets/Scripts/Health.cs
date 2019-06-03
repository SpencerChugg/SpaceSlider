using UnityEngine;
using System;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public IntSO healthSO;
    public int health;
    public UnityEvent onDeath;
    //public Action alsoOnDeath;

    public int CurrentHealth
    {
        get
        {
            if (healthSO)
            {
                return healthSO.Value;
            }
            return health;
        }

        set
        {
            if (healthSO)
            {
                healthSO.Value = value;
            }
            else
            {
                health = value;
            }
            if (value <= 0)
            {
                onDeath.Invoke();
            }
        }
    }

    void Start()
    {
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
