using UnityEngine;
using UnityEngine.Events;

public class CropPickUp : MonoBehaviour
{
    [SerializeField] UnityEvent OnCropPickup;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wheat") /*|| other.gameObject.CompareTag("Potato")*/ )
        {
            Destroy(other.gameObject);
            OnCropPickup.Invoke();
        }
    }
}