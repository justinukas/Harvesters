using UnityEngine;
using UnityEngine.Events;

public class WheatHarvest : MonoBehaviour
{
    [SerializeField] UnityEvent PopSFX;
    private Inventory script;

    private void OnCollisionEnter(Collision collider)
    {
        script = GameObject.Find("Open Bag").GetComponent<Inventory>();
        if (collider.gameObject.CompareTag("WheatSmall") && script.bagIsActive == true)
        {
            Debug.Log("collided with wheat");
            collider.gameObject.tag = "HarvestedWheat";
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            PopSFX.Invoke();
            script.WheatCollection();
        }
    }
}