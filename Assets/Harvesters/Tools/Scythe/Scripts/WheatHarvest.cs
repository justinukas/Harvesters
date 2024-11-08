using UnityEngine;

public class WheatHarvest : MonoBehaviour
{
    private BagInventory BagInventory;

    private void Start()
    {
        BagInventory = GameObject.FindGameObjectWithTag("Bag").GetComponent<BagInventory>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint contactPoint in collider.contacts) // this foreach is for checking for the correct local collider, the head of the scythe   
        {
            if (collider.gameObject.CompareTag("WheatSmall") && contactPoint.thisCollider.gameObject.name == "Head" && BagInventory.isBagOpen == true)
            {
                GameObject wheat = collider.gameObject;

                WheatDestruction WheatDestruction = wheat.GetComponent<WheatDestruction>();
                Harvestability Harvestability = wheat.GetComponent<Harvestability>();

                wheat.tag = "HarvestedWheat";
                wheat.GetComponent<Rigidbody>().isKinematic = false;

                gameObject.GetComponent<AudioSource>().Play();

                BagInventory.Collection();
                WheatDestruction.InvokeWheatDestruction();
            }
        }
    }
}
