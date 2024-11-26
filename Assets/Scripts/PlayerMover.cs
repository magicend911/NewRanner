using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float forwardSpeed = 5f;    // �������� �������� ������
    public float laneDistance = 3f;   // ���������� ����� ��������
    private int targetLane = 1;       // ������� ������ (0 = �����, 1 = �����������, 2 = ������)
    private Vector3 targetPosition;   // �������, ���� ������������

    void Start()
    {
        // ��������� ������� - ����������� ������
        targetPosition = transform.position;
    }

    void Update()
    {
        // �������� ������
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // ��������� �����
        if (Input.GetKeyDown(KeyCode.A) && targetLane > 0)
        {
            targetLane--; // ���������� �����
        }
        else if (Input.GetKeyDown(KeyCode.D) && targetLane < 2)
        {
            targetLane++; // ���������� ������
        }

        // ������������ ����� ������� �� ������ ��������� ������
        targetPosition = new Vector3((targetLane - 1) * laneDistance, transform.position.y, transform.position.z);

        // ����������� ��������� � ����� �������
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }
}