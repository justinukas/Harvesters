using UnityEngine;
using UnityEngine.Events;

public class WheatHarvest : MonoBehaviour
{
    [SerializeField] UnityEvent PopSFX;

    private Inventory script;

    private void OnTriggerEnter(Collider collider)
    {
        script = GameObject.Find("Open Bag").GetComponent<Inventory>();
        if (collider.gameObject.CompareTag("WheatSmall"))
        {
            Debug.Log("collided with wheat");
            collider.GetComponent<MeshCollider>().isTrigger = false;
            collider.GetComponent<Rigidbody>().isKinematic = false;

            PopSFX.Invoke();
            script.WheatCollection();
        }
    }
}