using UnityEngine;
public class ZigZagStrategy : MonoBehaviour, IEnemyMovement
{
    public float zigzagWidth = 2f; 
    public float zigzagSpeed = 5f; 
    public void Move(Transform enemyTransform, Transform targetTransform, float speed)
    {
        if (targetTransform == null) return;
        Vector3 directionToTarget = (targetTransform.position - enemyTransform.position).normalized;
        Vector3 forwardMove = directionToTarget * speed * Time.deltaTime;
        Vector3 rightDirection = new Vector3(-directionToTarget.y, directionToTarget.x, 0f); 
        Vector3 zigzagMove = rightDirection * Mathf.Sin(Time.time * zigzagSpeed) * zigzagWidth * Time.deltaTime;
        enemyTransform.position += forwardMove + zigzagMove;
    }
}
