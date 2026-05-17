using UnityEngine;

public class BulletBehavior : MonoBehaviour, IAttacker
{
    public float speed = 10f;
    public float lifeTime = 2f; 
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
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            if (target != null)
            {
                Attack(target);
            }
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
}