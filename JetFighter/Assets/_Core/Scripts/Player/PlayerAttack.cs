using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Attack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1f;
    private bool isShooting = false;
    private CancellationTokenSource cancellationTokenSource;

    public void Shoot()
    {
        if (!isShooting)
        {
            isShooting = true;
            cancellationTokenSource = new CancellationTokenSource();
            ShootAsync(cancellationTokenSource.Token).Forget();
        }
    }

    public void StopShooting()
    {
        if (isShooting)
        {
            isShooting = false;
            cancellationTokenSource.Cancel();
        }
    }

    private async UniTaskVoid ShootAsync(CancellationToken token)
    {
        while (isShooting)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            await UniTask.Delay((int)(fireRate * 1000), cancellationToken: token);
        }
    }
}