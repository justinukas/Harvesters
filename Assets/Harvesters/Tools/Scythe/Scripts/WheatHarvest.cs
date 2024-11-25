using UnityEngine;

public class WheatHarvest : MonoBehaviour
{
    [SerializeField] private BagInventory BagInventory;

    private void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint contactPoint in collider.contacts) // this foreach is for checking for the correct local collider, the head of the scythe   
        {
            if (collider.gameObject.CompareTag("WheatSmall") && contactPoint.thisCollider.gameObject.name == "Head" && BagInventory.isBagOpen == true)
            {
                GameObject wheat = collider.gameObject;

                Destruction destructionScript = wheat.GetComponent<Destruction>();
                Harvestability harvestability = wheat.GetComponent<Harvestability>();

                harvestability.Unparent();

                wheat.tag = "HarvestedWheat";
                wheat.GetComponent<Rigidbody>().isKinematic = false;

                gameObject.GetComponent<AudioSource>().Play();

                BagInventory.Collection("Wheat");
                destructionScript.DestroyObject(1f);
            }
        }
    }
}
