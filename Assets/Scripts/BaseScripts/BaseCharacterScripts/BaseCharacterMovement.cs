using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterMovement : MonoBehaviour
{
    [SerializeField] protected GameObject shipModel;
    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public abstract void CharacterMoving(Vector3 destination);
}
