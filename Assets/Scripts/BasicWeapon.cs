using UnityEngine;

public class BasicWeapon : IWeapon
{
    public void Fire(Transform firePoint, global::BulletPool pool)
    {
        GameObject bullet = pool.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        BulletBehavior behavior = bullet.GetComponent<BulletBehavior>();
        if (behavior != null)
        {
            behavior.SetPool(pool);
        }
    }
}