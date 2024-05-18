using UnityEngine;
using UnityEngine.Events;

public class WheatHarvest : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collider)
    {
        WheatDestruction destructionScript = collider.gameObject.GetComponent<WheatDestruction>();
        Inventory inventoryScript = GameObject.Find("Open Bag").GetComponent<Inventory>();

        if (collider.gameObject.CompareTag("WheatSmall") && inventoryScript.bagIsActive == true)
        {
            collider.gameObject.tag = "HarvestedWheat";
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            gameObject.transform.parent.GetComponent<AudioSource>().Play();

            inventoryScript.WheatCollection();
            destructionScript.DestructionInitiator();
        }
    }
}
