using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGun : Weapon
{
    public override void Shoot()
    {
        var p = GetProjectileFromPool();
        p.Init(this);
        p.SetOwnerNumber(GetOwnerPlayerNumber());
        p.Shoot(player.shootPos);
    }
}
