using UnityEngine;

public class DirectChaseStrategy : MonoBehaviour, IEnemyMovement
{
    public void Move(Transform enemyTransform, Transform targetTransform, float speed)
    {
        if (targetTransform == null) return;
        enemyTransform.position = Vector3.MoveTowards(
            enemyTransform.position,
            targetTransform.position,
            speed * Time.deltaTime
        );
    }
}