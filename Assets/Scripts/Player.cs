using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int MaxHealth => maxHealth;
    private int currentHealth;

    // ������� ��� ����������� ������ ��� ���������� ����
    public delegate void HealthChanged(int currentHealth);
    public event HealthChanged OnHealthChanged;

    void Start()
    {
        // ������������� ��������� ���������� ������
        currentHealth = maxHealth;

        // ���������� ����������� � ��������� ���������
        OnHealthChanged?.Invoke(currentHealth);
    }

    // ����� ��� ���������� ������
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ������������ � �������� 0 � maxHealth

        // ���������� �����������
        OnHealthChanged?.Invoke(currentHealth);

        // ���������, ��� �� �����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ��������� ������ ������
    private void Die()
    {
        Debug.Log("����� �����!");
        // ����� �������� ������ ����������� ������ ��� ���������� ����
    }

    // �������������� �������� (�����������)
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // ���������� �����������
        OnHealthChanged?.Invoke(currentHealth);
    }
}
