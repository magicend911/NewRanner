using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;    
    [SerializeField] private float laneDistance = 3f;

    private int targetLane = 1;       
    private Vector3 targetPosition;
    private Animator anim;


    void Start()
    {
        targetPosition = transform.position;
        anim = GetComponent<Animator>();

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
