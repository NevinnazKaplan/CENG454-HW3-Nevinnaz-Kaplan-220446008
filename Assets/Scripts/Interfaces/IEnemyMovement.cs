using UnityEngine;
public interface IEnemyMovement
{
    void Move(Transform enemyTransform, Transform targetTransform, float speed);
}