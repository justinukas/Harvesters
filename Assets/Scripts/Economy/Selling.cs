using UnityEngine;

public class Selling : MonoBehaviour
{
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Closed Bag" || collider.gameObject.tag == "Open Bag")
        {
            BagInventory inventoryScript = collider.gameObject.GetComponent<BagInventory>();
            MoneyCounter moneyCounterScript = GameObject.Find("MoneyNr").GetComponent<MoneyCounter>();
            BagToPlayer bagToPlayerScript = collider.gameObject.GetComponent<BagToPlayer>();

            if (collider.gameObject.tag == "Closed Bag")
            {
                moneyCounterScript.moneyNr += inventoryScript.value;

                inventoryScript.Sell();
                bagToPlayerScript.StartMoving();
            }

            if (collider.gameObject.tag == "Open Bag")
            {
                bagToPlayerScript.StartMoving();
            }
        }
        
        if (collider.gameObject.tag != "Closed Bag" && collider.gameObject.tag != "Open Bag")
        {
            collider.gameObject.transform.position = new Vector3(114f, 3f, 38f);
        }
    }
}
