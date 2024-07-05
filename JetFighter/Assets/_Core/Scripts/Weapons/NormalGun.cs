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
