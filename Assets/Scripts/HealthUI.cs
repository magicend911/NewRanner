using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Player playerHealth; // Ссылка на Player
    [SerializeField] private TextMeshProUGUI healthText; // Текст для отображения жизней

    void Start()
    {
        playerHealth.OnHealthChanged += UpdateHealthUI;
        UpdateHealthUI(playerHealth.MaxHealth); // Отобразить стартовые жизни
    }

    private void UpdateHealthUI(int currentHealth)
    {
        healthText.text = "Lives: " + currentHealth;
    }
}
