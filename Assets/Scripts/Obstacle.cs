using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 1; // Урон, который наносит препятствие

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, есть ли у объекта компонент PlayerHealth
        Player playerHealth = other.GetComponent<Player>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
