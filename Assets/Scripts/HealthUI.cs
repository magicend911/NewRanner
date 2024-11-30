using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Player playerHealth; // ������ �� Player
    [SerializeField] private TextMeshProUGUI healthText; // ����� ��� ����������� ������

    void Start()
    {
        playerHealth.OnHealthChanged += UpdateHealthUI;
        UpdateHealthUI(playerHealth.MaxHealth); // ���������� ��������� �����
    }

    private void UpdateHealthUI(int currentHealth)
    {
        healthText.text = "Lives: " + currentHealth;
    }
}
