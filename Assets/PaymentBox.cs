using UnityEngine;

public class PaymentBox : MonoBehaviour
{
    float timeEntered;
    float requiredStayLength = 4.0f;
    bool itemBought = false;

    [SerializeField] private BuyingStall buyingStall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Money Arm")
        {
            timeEntered = Time.time;
        }
        itemBought = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Money Arm")
        {
            Debug.Log("waiting...");
            if (Time.time - timeEntered > requiredStayLength && itemBought == false)
            {
                itemBought = true;
                Debug.Log("bought the shit");
                
                buyingStall.BuyItem();
            }
        }
    }
}
