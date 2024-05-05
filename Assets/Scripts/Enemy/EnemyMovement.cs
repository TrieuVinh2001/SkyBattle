using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : BaseCharacterMovement
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void CharacterMoving(Vector3 destination)
    {
       shipModel.transform.position = destination;
    }
}
