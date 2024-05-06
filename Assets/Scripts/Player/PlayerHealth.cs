using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EffectInfo;

public class PlayerHealth : BaseCharacterHealth
{
    protected override void Start()
    {
        base.Start();
        OnCharacterDead += EnemyHealth_OnCharacterDead;
    }

    private void EnemyHealth_OnCharacterDead()
    {
        EffectController.Instance.SpawnFX(EffectType.Explosion, controller.CharacterMovement.ShipModel.transform);
    }
}
