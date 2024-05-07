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
    public BaseCharacterMovement CharacterMovement => characterMovement;

    protected virtual void Awake()
    {
        characterHealth = GetComponent<BaseCharacterHealth>();
        characterShoot = GetComponent<BaseCharacterShoot>();
        characterMovement = GetComponent<BaseCharacterMovement>();
    }
    protected virtual void OnEnable()
    {
        characterShoot.SetNumberOfBulletPerShoot(shipSO.numberOfBulletsPerShot);
        characterHealth.SetMaxHealth(shipSO.MaxHealth);
    }

    protected virtual void Start()
    {
        SpawnCharacterModel();
    }

    protected virtual void Update()
    {
        characterShoot.CharacterShooting(shipSO.StartWeapon.weaponBulletPrefab);
    }

    protected virtual void SpawnCharacterModel()
    {
        this.shipModel.GetComponent<SpriteRenderer>().sprite = shipSO.CharacterModelSprite;
    }
}
