using UnityEngine;

public class Selling : MonoBehaviour
{
    [SerializeField] BagInventory BagInventory;
    [SerializeField] MoneyCounter MoneyCounter;
    [SerializeField] BagToPlayer BagToPlayer;

    private float value;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger entered");
        if (collider.gameObject.name == "Bag")
        {
            Debug.Log("bag collided");
            if (BagInventory.weight > 0)
            {
                value = BagInventory.weight * 2;
                MoneyCounter.moneyNr += value;
                MoneyCounter.UpdateMoneyCount();

                BagInventory.ResetAllCounters();
                BagToPlayer.StartMoving();

                BoatLeave();
            }
        }
    }

    private void BoatLeave()
    {
        Animator boatAnimator = gameObject.transform.parent.parent.GetComponent<Animator>();
        boatAnimator.SetTrigger("triggerLeave");     
    }
}
