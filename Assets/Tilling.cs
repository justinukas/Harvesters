using UnityEngine;
using UnityEngine.Events;

public class TillingOnTouch : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hoe"))
        {
            Destroy(gameObject);
            onTriggerEnter.Invoke();
        }
    }
}