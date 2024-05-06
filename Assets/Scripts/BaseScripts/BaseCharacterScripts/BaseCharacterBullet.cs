using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static EffectInfo;

[RequireComponent(typeof(PooledObject))]
public abstract class BaseCharacterBullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected BaseCharacterController baseCharacterController;
    [Space, Header("Bullet properties")]
    [SerializeField] protected float speedBullet;
    protected float damageCharaccterRecived;
    [Space, Header("Bullet VFX")]
    [SerializeField] protected GameObject explosionEffect;
    [Space, Header(("Layer affect"))]
    [SerializeField] protected LayerMask activeAffect;
    [SerializeField] protected float radiusAffect;
    [Space, Header("Time Delay Deactive bullet")]
    [SerializeField] protected float timeDelay;
    protected private PooledObject pooledObject;
    protected Vector2 shootDirection;
    protected void OnEnable()
    {
        //damageCharaccterRecived = GetDamage();
        Deactive();
    }

    protected virtual void Start()
    {
        pooledObject = GetComponent<PooledObject>();
    }

    protected virtual void Update()
    {
        BulletMoving();
    }

    protected virtual void BulletMoving()
    {
        transform.Translate(shootDirection * speedBullet * Time.deltaTime);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable iDamageable) && collision.GetComponent<BaseCharacterController>().ShipSO.ShipType != baseCharacterController.ShipSO.ShipType)
        {
            iDamageable = collision.GetComponent<IDamageable>();
            BaseCharacterController collisionController = collision.GetComponent<BaseCharacterController>();
            if (collisionController != null && iDamageable != null )
            {
                iDamageable.ReciveDamage(baseCharacterController.ShipSO.Damage /*+ baseCharacterController.ShipSO.StartWeapon.weaponDamage*/ - collisionController.ShipSO.Armor);
                EffectController.Instance.SpawnFX(EffectType.Hit, collision.transform);
                ReleaseBulletToStack();
            } 
        }
    }

    public virtual void Deactive()
    {
        StartCoroutine(DeactivateRoutine(timeDelay));
    }

    private IEnumerator DeactivateRoutine(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        ReleaseBulletToStack();
    }

    protected virtual void ReleaseBulletToStack()
    {
        pooledObject.Release(baseCharacterController.CharacterShoot.BulletsStack);
        gameObject.SetActive(false);
    }

    public void SetBaseCharacterController(BaseCharacterController baseCharacterController)
    {
       this.baseCharacterController = baseCharacterController;
    }

    public float GetDamage()
    {
        if(baseCharacterController != null)
        {
            return baseCharacterController.ShipSO.Damage + baseCharacterController.ShipSO.StartWeapon.weaponDamage;
        }
        return 0;
    }

    public void GetShootDirection(Vector2 dir)
    {
        shootDirection = dir;
    }
}
