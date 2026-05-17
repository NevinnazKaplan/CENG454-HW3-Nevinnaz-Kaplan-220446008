using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon decoratedWeapon;

    public WeaponDecorator(IWeapon weapon)
    {
        this.decoratedWeapon = weapon;
    }

    public virtual void Fire(Transform firePoint, global::BulletPool pool)
    {
        decoratedWeapon.Fire(firePoint, pool);
    }
}