using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;    
    [SerializeField] private float laneDistance = 3f;
    [SerializeField] private Animator anim;

    private int targetLane = 1;       
    private Vector3 targetPosition;


    void Start()
    {
        targetPosition = transform.position;

    }

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A) && targetLane > 0)
        {
            targetLane--;
            anim.SetTrigger("ChangeLaneTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.D) && targetLane < 2)
        {
            targetLane++;
            anim.SetTrigger("ChangeLaneTrigger");
        }

        targetPosition = new Vector3((targetLane - 1) * laneDistance, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("JumpTrigger"); 
        }
    }
}
