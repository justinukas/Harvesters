using UnityEngine;

public class Selling : MonoBehaviour
{
    private BagInventory inventoryScript;
    private MoneyCounter moneyCounterScript;
    private BagToPlayer bagToPlayerScript;

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Closed Bag")
        {
            inventoryScript = collider.gameObject.GetComponent<BagInventory>();
            moneyCounterScript = GameObject.Find("MoneyNr").GetComponent<MoneyCounter>();
            bagToPlayerScript = collider.gameObject.GetComponent<BagToPlayer>();

            float bagValue = inventoryScript.value;
            float moneyNum = moneyCounterScript.moneyNr;

            moneyNum += bagValue;

            inventoryScript.Sell();
            bagToPlayerScript.StartMoving();
        }
    }
}
