using UnityEngine;
using UnityEngine.Events;

public class WheatHarvest : MonoBehaviour
{
    [SerializeField] UnityEvent PopSFX;

    private void OnCollisionEnter(Collision collider)
    {
        Inventory inventoryScript = GameObject.Find("Open Bag").GetComponent<Inventory>();
        if (collider.gameObject.CompareTag("WheatSmall") && inventoryScript.bagIsActive == true)
        {
            collider.gameObject.tag = "HarvestedWheat";
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            PopSFX.Invoke();
            inventoryScript.WheatCollection();
        }
    }
}
