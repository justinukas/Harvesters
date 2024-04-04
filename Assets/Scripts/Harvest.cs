using UnityEngine;
using UnityEngine.Events;

public class DisappearOnTouch : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wheat"))
        {
            Destroy(other.gameObject);
            onTriggerEnter.Invoke();
        }
    }
}