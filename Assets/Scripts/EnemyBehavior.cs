using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IAttacker, IDamageable
{
    public Transform targetCore;
    public float moveSpeed = 3f;
    [SerializeField] private int damage = 10;

    public int Damage => damage;

    private IEnemyMovement movementStrategy;

    private void Start()
    {
        movementStrategy = GetComponent<IEnemyMovement>();

        if (movementStrategy == null)
        {
            Debug.LogWarning("Enemy doesn't have a movement strategy attached!");
        }
        if (targetCore == null)
        {
            GameObject coreObject = GameObject.Find("Core");
            if (coreObject != null)
            {
                targetCore = coreObject.transform;
            }
        }
    }

    private void Update()
    {
        if (movementStrategy != null && targetCore != null)
        {
            movementStrategy.Move(transform, targetCore, moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableTarget = collision.GetComponent<IDamageable>();
        if (damageableTarget != null && !collision.CompareTag("Bullet"))
        {
            Attack(damageableTarget);
            gameObject.SetActive(false);
        }
    }

    public void Attack(IDamageable target)
    {
        target.TakeDamage(Damage);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Enemy hit!");
        gameObject.SetActive(false); 
    }
}