using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Pool;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int fireRate;
    private bool canShoot = true;

    private ObjectPool<Projectile> projectilePool;

    private void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject);
    }
    public abstract void Shoot();

    public void TryShoot()
    {
        if (!canShoot) { return; }
        
        Shoot();
        CanShootAgain();
    }
    
    private async void CanShootAgain()
    {
        canShoot = false;
        await UniTask.Delay(fireRate);
        canShoot = true; 
    }
    
    // * =====================================================================================================================================
    // * 

    protected Projectile GetProjectileFromPool()
    {
        return projectilePool.Get();
    }

    protected void ReturnProjectileToPool(Projectile projectile)
    {
        projectilePool.Release(projectile);
    }
    
    // * =====================================================================================================================================
    // * POOL
    
    private Projectile CreatePooledItem()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        return bulletObject.GetComponent<Projectile>();
    }

    private void OnTakeFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Projectile projectile)
    {
        Destroy(projectile.gameObject);
    }
}