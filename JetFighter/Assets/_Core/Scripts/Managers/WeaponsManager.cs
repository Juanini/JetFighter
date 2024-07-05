using UnityEngine;

public class WeaponsManager : Singleton<WeaponsManager>
{
    [SerializeField] private Weapon startingWeapon;

    public Weapon GetStartingWeapon()
    {
        return Instantiate(startingWeapon);
    }
}
