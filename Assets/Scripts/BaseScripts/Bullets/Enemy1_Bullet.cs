using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Bullet : BaseCharacterBullet
{
    protected override void BulletMoving()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speedBullet * Time.deltaTime * -1f);
    }
}
