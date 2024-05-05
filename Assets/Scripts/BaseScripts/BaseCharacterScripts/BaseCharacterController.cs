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
    public BaseShipSO ShipSO => shipSO;
    public BaseCharacterHealth CharacterHealth => characterHealth;
    public BaseCharacterShoot CharacterShoot => characterShoot;

    protected virtual void OnEnable()
    {

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
        var shipModel = Instantiate(shipSO.CharacterModel);
    }
}
