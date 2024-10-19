using UnityEngine;

public class Selling : MonoBehaviour
{
    [SerializeField] BagInventory BagInventory;
    [SerializeField] MoneyCounter MoneyCounter;

    private float value;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Bag")
        {
            if (BagInventory.weight > 0)
            {
                value = BagInventory.weight * 2;
                MoneyCounter.moneyNr += value;
                MoneyCounter.UpdateMoneyCount();

                BagInventory.ResetAllCounters();
                BoatLeave();
            }
        }
    }

    private void BoatLeave()
    {
        Animator boatAnimator = gameObject.transform.parent.GetComponent<Animator>();
        boatAnimator.SetTrigger("triggerLeave");     
    }
}
