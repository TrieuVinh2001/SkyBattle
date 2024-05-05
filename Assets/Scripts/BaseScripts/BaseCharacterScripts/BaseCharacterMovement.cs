using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterMovement : MonoBehaviour
{
    [Header("Character properties")]
    [SerializeField] protected float ChacterSpeed;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public abstract void CharacterMoving(Vector3 destination);
}
