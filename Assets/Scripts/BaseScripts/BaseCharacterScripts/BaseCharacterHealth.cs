using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterHealth : MonoBehaviour,IDamageable
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;

    public virtual void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void ReciveDamage(float damage)
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
        //Instantiate(explosionEffect);
        //Destroy(gameObject);
    }
}
