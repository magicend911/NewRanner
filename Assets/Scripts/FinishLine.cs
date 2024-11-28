using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject winText; // Панель победы

    private void Start()
    {
        winText.SetActive(false); // Скрываем панель при старте игры
    }

    private void OnTriggerEnter(Collider other) // Срабатывает при пересечении триггера
    {
        if (other.GetComponent<Player>() != null) // Проверяем, есть ли компонент Player
        {
            winText.SetActive(true); // Показываем панель победы
            Time.timeScale = 0f; // Останавливаем время
        }
    }
}
