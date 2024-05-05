using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public enum ShipType { Player, enemy,boss, other}
public class BaseShipSO : ScriptableObject
{
    public ShipType ShipType;
    public Sprite CharacterModelSprite;
    public PooledObject BulletPrefab;
    public WeaponSO StartWeapon;
    public float Armor;
    public float Damage;
    public float MaxHealth;
    public float CharacterSpeed;
    [Range(0, 100)]
    public int CriticalRate;
    public int numberOfBulletsPerShot;
    [Range(1, 10)]
    public int CharacterLever;
    public string Name;
    public string Description;
}
