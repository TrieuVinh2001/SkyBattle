using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BaseCharacterHealth), typeof(BaseCharacterShoot))]
public abstract class BaseCharacterController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected BaseCharacterHealth characterHealth;
    [SerializeField] protected BaseCharacterShoot characterShoot;
    [SerializeField] protected BaseCharacterMovement characterMovement;
    [SerializeField] private BaseShipSO shipSO;
    [Space, Header("Base Properties")]
    [SerializeField] protected float characterSpeed;
    public BaseShipSO ShipSO => shipSO;
    public BaseCharacterHealth CharacterHealth => characterHealth;
    public BaseCharacterShoot CharacterShoot => characterShoot;

    protected virtual void Start()
    {
        characterHealth = GetComponent<BaseCharacterHealth>();
        characterShoot = GetComponent<BaseCharacterShoot>();
        characterMovement = GetComponent<BaseCharacterMovement>();

        PoolingObject.Instance.SetupPool(characterShoot.BulletsStack, shipSO.BulletPrefab, 1);
        characterHealth.SetMaxHealth(shipSO.MaxHealth);
        SetCharacterShootThem();
    }

    protected virtual void Update()
    {
        characterMovement.CharacterMoving(characterSpeed);
    }

    protected virtual void FixedUpdate()
    {
        characterShoot.CharacterShooting(shipSO.BulletPrefab);
    }

    protected virtual void SetCharacterShootThem()
    {
        foreach (var bullet in characterShoot.BulletsStack)
        {
            bullet.GetComponent<BaseCharacterBullet>().SetBaseCharacterController(this);
        }
    }
}
