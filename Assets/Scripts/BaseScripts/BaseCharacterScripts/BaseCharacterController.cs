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
    [SerializeField] protected BaseShipSO shipSO;
    [SerializeField] protected GameObject shipModel;
    public BaseShipSO ShipSO => shipSO;
    public BaseCharacterHealth CharacterHealth => characterHealth;
    public BaseCharacterShoot CharacterShoot => characterShoot;

    protected virtual void OnEnable()
    {
        characterShoot.SetNumberOfBulletPerShoot(shipSO.numberOfBulletsPerShot);
    }

    protected virtual void OnDisable() 
    {
        characterHealth.SetMaxHealth(shipSO.MaxHealth);
    }

    protected virtual void Start()
    {
        characterHealth = GetComponent<BaseCharacterHealth>();
        characterShoot = GetComponent<BaseCharacterShoot>();
        characterMovement = GetComponent<BaseCharacterMovement>();

        PoolingObject.Instance.SetupPool(characterShoot.BulletsStack, shipSO.BulletPrefab, 1);
        SetCharacterIsShooting();
        SpawnCharacterModel();
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        characterShoot.CharacterShooting(shipSO.BulletPrefab);
    }

    protected virtual void SetCharacterIsShooting()
    {
        foreach (var bullet in characterShoot.BulletsStack)
        {
            bullet.GetComponent<BaseCharacterBullet>().SetBaseCharacterController(this);
        }
    }

    protected virtual void SpawnCharacterModel()
    {
        this.shipModel.GetComponent<SpriteRenderer>().sprite = shipSO.CharacterModel;
    }
}
