using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 1; // ����, ������� ������� �����������

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ���� �� � ������� ��������� PlayerHealth
        Player playerHealth = other.GetComponent<Player>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
