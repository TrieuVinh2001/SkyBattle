using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject effectShoot;
    [SerializeField] protected Transform pointShoot;

    protected virtual void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, pointShoot.position, Quaternion.identity);
    }
}
