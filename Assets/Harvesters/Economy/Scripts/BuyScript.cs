using UnityEngine;

public class BuyScript : MonoBehaviour
{
    // get the money stuff
    [SerializeField] private MoneyCounter MoneyCounter;

    // float numbers for calculating how long the object has been in an area
    private readonly float requiredStayLength = 4.0f;
    private float timeOnEnter;
    private int price;

    void OnTriggerEnter(Collider collider)
    {
        timeOnEnter = Time.time;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<SeedBagManager>())
        {
            SeedBagManager seedBagManager = collider.gameObject.GetComponent<SeedBagManager>();

            switch (seedBagManager.bagVariant)
            {
                case "Carrot":
                    price = 10;
                    break;
                case "Wheat":
                    price = 15;
                    break;
                case "Pumpkin":
                    price = 30;
                    break;
            }

            if (seedBagManager.timesUsed >= 50 && Time.time - timeOnEnter >= requiredStayLength && MoneyCounter.moneyNr >= price)
            {
                MoneyCounter.moneyNr -= price;
                MoneyCounter.UpdateMoneyCount();

                BuyingHandler seedBagBuyingHandler = collider.gameObject.GetComponent<BuyingHandler>();

                seedBagBuyingHandler.BuyBag(ref seedBagManager.timesUsed, seedBagManager.maxTimesUsed);
            }
        }
    }
}
