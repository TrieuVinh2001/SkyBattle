using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterBullet : MonoBehaviour
{
    [SerializeField] protected float speedBullet;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionEffect;


    protected virtual void Update()
    {
        transform.position = Vector2.up * speedBullet * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            DestroyBullet();
        }
    }
    
    protected virtual void DestroyBullet()
    {
        Instantiate(explosionEffect);
        Destroy(gameObject);
    }
}
