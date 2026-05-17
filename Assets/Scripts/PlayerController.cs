using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletPool bulletPool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletPool != null)
        {
            GameObject bullet = bulletPool.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            BulletBehavior behavior = bullet.GetComponent<BulletBehavior>();
            if (behavior != null)
            {
                behavior.SetPool(bulletPool);
            }
        }
    }
}