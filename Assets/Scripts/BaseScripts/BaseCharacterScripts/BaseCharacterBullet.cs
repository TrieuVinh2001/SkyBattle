using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

    protected abstract void BulletMoving();
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable iDamageable))
        {
            iDamageable = collision.GetComponent<IDamageable>();
            if (collision.GetComponent<BaseCharacterController>() != null && iDamageable != null)
            {
                if (collision.GetComponent<BaseCharacterController>().ShipSO.ShipType == baseCharacterController.ShipSO.ShipType) return;
                iDamageable.ReciveDamage(damageCharaccterRecived - collision.GetComponent<BaseCharacterController>().ShipSO.Armor);
            } 
            ReleaseBulletToStack();
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
}
