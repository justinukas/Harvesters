using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    // get the money stuff
    private GameObject moneyTextbox;
    private MoneyCounter moneyCounter;
    void Start()
    {
        moneyTextbox = GameObject.Find("MoneyNr");
        moneyCounter = moneyTextbox.GetComponent<MoneyCounter>();
    }

    // float numbers for calculating how long the object has been in an area
    float minStayingLength = 4f;
    float timeOnEnter;

    void OnTriggerEnter(Collider collider)
    {
        timeOnEnter = Time.time;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "CarrotBag")
        {
            // script reference
            CarrotSeed carrotSeedScript = collider.gameObject.transform.parent.GetComponent<CarrotSeed>();

            if (carrotSeedScript.timesUsed >= 10 && Time.time - timeOnEnter >= minStayingLength && moneyCounter.moneyNr >= 10)
            {
                moneyCounter.moneyNr -= 10;

                carrotSeedScript.Bought();
            }
        }

        if (collider.gameObject.tag == "WheatBag")
        {
            // script reference
            WheatSeed wheatSeedScript = collider.gameObject.transform.parent.GetComponent<WheatSeed>();

            if (wheatSeedScript.timesUsed >= 10 && Time.time - timeOnEnter >= minStayingLength && moneyCounter.moneyNr >= 15)
            {
                moneyCounter.moneyNr -= 15;
                wheatSeedScript.Bought();
            }
        }
    }
}
