using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CoreBehavior core;
    public Text healthText;

    private void OnEnable()
    {
        if (core != null)
        {
            core.OnCoreDamaged += UpdateHealthUI;
        }
    }

    private void OnDisable()
    {
        if (core != null)
        {
            core.OnCoreDamaged -= UpdateHealthUI;
        }
    }
    private void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Core Health: " + currentHealth;
        }
        Debug.Log("Core is damaged Remaining Health: " + currentHealth);
    }
}