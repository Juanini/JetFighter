using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGun : Weapon
{
    public Player player;
    
    public override void Shoot()
    {
        var p = GetProjectileFromPool();
        p.Shoot(player.shootPos);
    }
}