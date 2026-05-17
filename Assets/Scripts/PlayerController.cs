using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public BulletPool bulletPool;
    public Transform firePoint;

    private IWeapon currentWeapon;

    private void Start()
    {
        currentWeapon = new BasicWeapon();

        if (firePoint == null)
        {
            firePoint = transform;
        }
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            Shoot();
        }
        if (Keyboard.current != null && Keyboard.current.gKey.wasPressedThisFrame)
        {
            UpgradeWeapon();
        }
    }

    private void Shoot()
    {
        if (currentWeapon != null && bulletPool != null)
        {
            currentWeapon.Fire(firePoint, bulletPool);
        }
    }

    public void UpgradeWeapon()
    {
        currentWeapon = new DoubleShotDecorator(currentWeapon);
        Debug.Log("Weapon Upgraded! Double Shooting.");
    }
}