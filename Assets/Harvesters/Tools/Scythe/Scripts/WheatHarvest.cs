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
            if (contactPoint.otherCollider.gameObject.GetComponent<WheatDestruction>())
            {
                WheatDestruction WheatDestruction = contactPoint.otherCollider.gameObject.GetComponent<WheatDestruction>();
                Harvestability Harvestability = contactPoint.otherCollider.gameObject.GetComponent<Harvestability>();

                if (collider.gameObject.CompareTag("WheatSmall") && contactPoint.thisCollider.gameObject.name == "Head" && BagInventory.isBagOpen == true)
                {
                    collider.gameObject.tag = "HarvestedWheat";
                    collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                    gameObject.GetComponent<AudioSource>().Play();

                    BagInventory.WheatCollection();
                    WheatDestruction.InvokeWheatDestruction();
                }
            }
        }
    }
}
