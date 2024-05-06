using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EffectInfo;

public abstract class BaseCharacterHealth : MonoBehaviour,IDamageable
{
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
        EffectController.Instance.SpawnFX(EffectType.Hit, controller.CharacterMovement.ShipModel.transform);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
    }

    protected virtual void Death()
    {
        Debug.Log("death");
        //EffectController.Instance.SpawnFX(EffectType.Explosion, controller.CharacterMovement.ShipModel.transform);
        gameObject.SetActive(false);
    }
}
