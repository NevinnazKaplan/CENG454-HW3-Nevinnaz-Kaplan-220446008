using UnityEngine;

public class BulletBehavior : MonoBehaviour, IAttacker
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public float detectionRadius = 1.5f;

    private float currentLifeTime;
    private BulletPool myPool;

    [SerializeField] private int damage = 20;
    public int Damage => damage;

    public void SetPool(BulletPool pool)
    {
        myPool = pool;
    }

    private void OnEnable()
    {
        currentLifeTime = lifeTime;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Enemy") && hit.gameObject.activeInHierarchy)
            {
                IDamageable target = hit.GetComponent<IDamageable>();
                if (target != null)
                {
                    Attack(target);
                }
                ReturnToPool();
                break;
            }
        }

        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            ReturnToPool();
        }
    }

    public void Attack(IDamageable target)
    {
        target.TakeDamage(Damage);
    }

    private void ReturnToPool()
    {
        if (myPool != null)
            myPool.ReturnToPool(gameObject);
        else
            gameObject.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}