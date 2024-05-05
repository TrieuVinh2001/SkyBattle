using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType { Player, enemy, other}
public class BaseShipSO : ScriptableObject
{
    public ShipType ShipType;
    public GameObject CharacterModel;
    public PooledObject BulletPrefab;
    public WeaponSO StartWeapon;
    public float Armor;
    public float Damage;
    public float MaxHealth;
    public float CharacterSpeed;
    [Range(0, 100)]
    public int CriticalRate;
    [Range(1, 10)]
    public int CharacterLever;
    public string Name;
    public string Description;
}
