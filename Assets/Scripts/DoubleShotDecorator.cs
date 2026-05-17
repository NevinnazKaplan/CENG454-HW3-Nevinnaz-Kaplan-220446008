using UnityEngine;

public class DoubleShotDecorator : WeaponDecorator
{
    public DoubleShotDecorator(IWeapon weapon) : base(weapon) { }

    public override void Fire(Transform firePoint, global::BulletPool pool)
    {
        base.Fire(firePoint, pool);

        GameObject extraBullet = pool.GetBullet();
        extraBullet.transform.position = firePoint.position + firePoint.right * 0.5f;
        extraBullet.transform.rotation = firePoint.rotation;

        BulletBehavior behavior = extraBullet.GetComponent<BulletBehavior>();
        if (behavior != null)
        {
            behavior.SetPool(pool);
        }
    }
}