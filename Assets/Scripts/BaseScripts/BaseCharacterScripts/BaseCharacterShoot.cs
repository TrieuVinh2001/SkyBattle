using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BaseCharacterShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected GameObject effectShoot;
    [SerializeField] protected Transform pointShoot;
    protected Stack<PooledObject> bulletsStack = new Stack<PooledObject>();
    public Stack<PooledObject> BulletsStack => bulletsStack;

    public virtual void CharacterShooting(PooledObject bulletPrefab)
    {
        GameObject bulletObject = PoolingObject.Instance.GetPooledObject(bulletsStack, bulletPrefab).gameObject;
        if (bulletObject == null) return;
        bulletObject.SetActive(true);
    }
}
