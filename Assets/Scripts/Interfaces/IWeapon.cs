using UnityEngine;

public interface IWeapon
{
    void Fire(Transform firePoint, global::BulletPool pool);
}