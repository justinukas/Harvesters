using UnityEngine;
using UnityEngine.Events;

public class DisappearOnTouch : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            Destroy(gameObject);
            onTriggerEnter.Invoke();
        }
    }
}