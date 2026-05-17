using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CoreBehavior core;

    private void OnEnable()
    {
        if (core != null)
        {
            core.OnCoreDestroyed += HandleGameOver;
        }
    }

    private void OnDisable()
    {
        if (core != null)
        {
            core.OnCoreDestroyed -= HandleGameOver;
        }
    }

    private void HandleGameOver()
    {
        Debug.Log("GAME OVER! Core is breached.");
    }
}