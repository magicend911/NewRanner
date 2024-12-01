using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject winText;

    private void Start()
    {
        winText.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<Player>() != null)
        {
            winText.SetActive(true);            
        }
    }
}
