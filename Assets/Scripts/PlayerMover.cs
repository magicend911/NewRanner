using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float forwardSpeed = 5f;    // Скорость движения вперед
    public float laneDistance = 3f;   // Расстояние между полосами
    private int targetLane = 1;       // Текущая полоса (0 = левая, 1 = центральная, 2 = правая)
    private Vector3 targetPosition;   // Позиция, куда перемещаемся

    void Start()
    {
        // Начальная позиция - центральная полоса
        targetPosition = transform.position;
    }

    void Update()
    {
        // Движение вперед
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Обработка ввода
        if (Input.GetKeyDown(KeyCode.A) && targetLane > 0)
        {
            targetLane--; // Сдвигаемся влево
        }
        else if (Input.GetKeyDown(KeyCode.D) && targetLane < 2)
        {
            targetLane++; // Сдвигаемся вправо
        }

        // Рассчитываем новую позицию на основе выбранной полосы
        targetPosition = new Vector3((targetLane - 1) * laneDistance, transform.position.y, transform.position.z);

        // Перемещение персонажа к новой позиции
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }
}
