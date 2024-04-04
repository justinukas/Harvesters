using UnityEngine;
using UnityEngine.Events;
// sis kodas sunaikina dirta kai ji paliecia kauptukas

public class TillingOnTouch : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dirt"))
        {
            Destroy(other.gameObject);
            onTriggerEnter.Invoke();
        }
    }
}