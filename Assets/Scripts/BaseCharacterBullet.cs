using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterBullet : MonoBehaviour
{
    [SerializeField] protected float speedBullet;
    [SerializeField] protected float damage;
    [SerializeField] private GameObject explosionEffect;


    protected virtual void Update()
    {
        transform.position = Vector2.up * speedBullet * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
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
