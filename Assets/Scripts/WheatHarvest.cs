using UnityEngine;

public class WheatHarvest : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collider)
    {
        WheatDestruction destructionScript = collider.gameObject.GetComponent<WheatDestruction>();
        WheatGrowth growthScript = collider.gameObject.GetComponent<WheatGrowth>();
        OpenBagInventory inventoryScript = GameObject.Find("Open Bag").GetComponent<OpenBagInventory>();

        if (collider.gameObject.CompareTag("WheatSmall") && inventoryScript.bagIsActive == true && growthScript.isHarvestable == true)
        {
            collider.gameObject.tag = "HarvestedWheat";
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            gameObject.GetComponent<AudioSource>().Play();

            inventoryScript.WheatCollection();
            destructionScript.DestructionInitiator();
        }
    }
}
