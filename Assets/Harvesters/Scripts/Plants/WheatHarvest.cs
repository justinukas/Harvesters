using UnityEngine;

public class WheatHarvest : MonoBehaviour
{
    public GameObject OpenBag;

    private void OnCollisionEnter(Collision collider)
    {
        WheatDestruction destructionScript = collider.gameObject.GetComponent<WheatDestruction>();
        WheatGrowth growthScript = collider.gameObject.GetComponent<WheatGrowth>();
        BagInventory inventoryScript = GameObject.Find("Bag").GetComponent<BagInventory>();

        foreach (ContactPoint contactPoint in collider.contacts) // this foreach is for checking for the correct local collider
        {
            if (collider.gameObject.CompareTag("WheatSmall") && inventoryScript.bagIsOpen == true && growthScript.isHarvestable == true && contactPoint.thisCollider.gameObject.name == "Head")
            {
                collider.gameObject.tag = "HarvestedWheat";
                collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                gameObject.GetComponent<AudioSource>().Play();

                inventoryScript.WheatCollection();
                destructionScript.DestructionInitiator();
            }
        }
    }
}
