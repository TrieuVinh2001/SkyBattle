using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterHealth : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    [SerializeField] private GameObject explosionEffect;
    
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void GetDamage(float damage)
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Instantiate(explosionEffect);
        Destroy(gameObject);
    }
}
