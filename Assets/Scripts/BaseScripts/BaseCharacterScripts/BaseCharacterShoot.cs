using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BaseCharacterShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected GameObject effectShoot;
    [SerializeField] protected Transform pointShoot;
    [Space,Header("Properties")]
    [Header("Time To Delay BTW Shoot")]
    [SerializeField] protected float timeDelayMax;
    [Header("Range Per Shoot")]
    [Range(0, 360)]
    [SerializeField] protected float startAngle, endAngle;
    protected float timeDelay;
    protected int numberBullet;
    protected Stack<PooledObject> bulletsStack = new Stack<PooledObject>();
    public Stack<PooledObject> BulletsStack => bulletsStack;

    public virtual void SetNumberOfBulletPerShoot(int number)
    {
        this.numberBullet = number;
    }

    public virtual void CharacterShooting(PooledObject bulletPrefab)
    {
        timeDelay -= Time.fixedDeltaTime;
        if (timeDelay <= 0)
        {
            float angleStep = (endAngle - startAngle) / numberBullet;
            float angle = startAngle;
            for (int i = 0; i < numberBullet; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
                Vector3 bulMoveDir = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveDir - transform.position).normalized;
                GameObject bulletObject = PoolingObject.Instance.GetPooledObject(bulletsStack, bulletPrefab).gameObject;
                bulletObject.transform.position = pointShoot.position;
                bulletObject.SetActive(true);
                angle += angleStep;
                timeDelay = timeDelayMax;
            }
        }
    }

    protected int IncreaseNumberOfBulletPerShoot()
    {
        return numberBullet ++;
    }
}
