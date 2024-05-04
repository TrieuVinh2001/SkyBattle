using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterShoot : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected GameObject effectShoot;
    [SerializeField] protected Transform pointShoot;

    protected virtual void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, pointShoot.position, Quaternion.identity);
    }
}
