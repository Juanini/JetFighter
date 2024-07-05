using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private int timeToDisable;
    private int playerOwnerNumber;
    private Weapon weaponOwner;
    
    private void OnEnable()
    {
        DisableAfterTime();
    }

    public void Init(Weapon _weaponOwner)
    {
        weaponOwner = _weaponOwner;
    }
    
    private async void DisableAfterTime()
    {
        await UniTask.Delay(timeToDisable);
        gameObject.SetActive(false);
        weaponOwner.ReturnProjectileToPool(this);
    }

    public void HandleHit()
    {
        gameObject.SetActive(false);
    }

    public abstract void Shoot(Transform _shootPos);

    public void SetOwnerNumber(int _number)
    {
        playerOwnerNumber = _number;
    }
    public int GetOwnerNumber()
    {
        return playerOwnerNumber;
    }
}
