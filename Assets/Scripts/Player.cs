using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int MaxHealth => maxHealth;
    private int currentHealth;

    // Событие для отображения жизней или завершения игры
    public delegate void HealthChanged(int currentHealth);
    public event HealthChanged OnHealthChanged;

    void Start()
    {
        // Устанавливаем начальное количество жизней
        currentHealth = maxHealth;

        // Уведомляем подписчиков о начальном состоянии
        OnHealthChanged?.Invoke(currentHealth);
    }

    // Метод для уменьшения жизней
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ограничиваем в пределах 0 и maxHealth

        // Уведомляем подписчиков
        OnHealthChanged?.Invoke(currentHealth);

        // Проверяем, жив ли игрок
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Обработка смерти игрока
    private void Die()
    {
        Debug.Log("Игрок погиб!");
        // Можно добавить логику перезапуска уровня или завершения игры
    }

    // Восстановление здоровья (опционально)
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Уведомляем подписчиков
        OnHealthChanged?.Invoke(currentHealth);
    }
}
