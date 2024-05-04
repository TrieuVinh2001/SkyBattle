using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterMovement : MonoBehaviour
{
    [Header("Character properties")]
    [SerializeField] protected float ChacterSpeed;
    [SerializeField]
    public virtual  void CharacterMoving()
    {
        // Moving
    }
}
