using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Player player; 
    [SerializeField] private TextMeshProUGUI healthText;

    private void OnEnable()
    {
        player.HealthChanged += onHealthChanged;
    }
    private void OnDisable()
    {
        player.HealthChanged -= onHealthChanged;
    }

    private void onHealthChanged(int health)
    {
        healthText.text = health.ToString();
    }
}
