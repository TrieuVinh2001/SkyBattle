using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemsType { Weapon, ItemIncreaseProperty}
public class ItemsSO : ScriptableObject
{
    public ItemsType ItemType;
    public Sprite itemModel;
}
