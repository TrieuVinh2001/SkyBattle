using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EffectInfo;
using System;
public abstract class BaseCharacterHealth : MonoBehaviour,IDamageable
{
    public event Action OnHealthChange;
    public event Action OnCharacterDead;
    protected float maxHealth;
    protected float currentHealth;
    protected BaseCharacterController controller;   

    protected virtual void Start()
    {
        controller = GetComponent<BaseCharacterController>();
    }

    public virtual void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = this.maxHealth;
    }

    public void ReciveDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChange?.Invoke();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
    }

    protected virtual void Death()
    {
        OnHealthChange?.Invoke();
        gameObject.SetActive(false);
    }
}
