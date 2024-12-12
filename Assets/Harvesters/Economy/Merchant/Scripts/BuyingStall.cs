using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class BuyingStall : MonoBehaviour
{
    [SerializeField] private MoneyCounter moneyCounter;
    [SerializeField] private PaymentBox paymentBox;

    [HideInInspector] public List<string> itemsOnStall = new List<string>();

    [HideInInspector] public float price = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnboughtTool"))
        {
            if (!itemsOnStall.Contains(other.name))
            {
                AddItemToList(other.name);
                CalculatePrice();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UnboughtTool"))
        {
            if (itemsOnStall.Contains(other.name))
            {
                itemsOnStall.Remove(other.name);
                CalculatePrice();
            }
        }
    }

    private void AddItemToList(string item)
    {
        itemsOnStall.Add(item);
    }

    private void CalculatePrice()
    {
        price = 0;
        foreach (string item in itemsOnStall)
        {
            switch (item)
            {
                case "Scythe":
                    price += 25;
                    break;
                case "Axe":
                    price += 30;
                    break;
                case "Wheat Seed Bag":
                    price += 25;
                    break;
                case "Pumpkin Seed Bag":
                    price += 100;
                    break;
            }
        }
        if (price > 0)
        {
            paymentBox.UIEnable(true);
        }
        else paymentBox.UIEnable(false);
    }

    // is called by PaymentBox script OnTriggerStay method
    public void BuyItem()
    {
        CalculatePrice(); // recalculate price
        if (itemsOnStall.Count > 0)
        {
            if (moneyCounter.moneyNr >= price)
            {
                moneyCounter.moneyNr -= price;
                moneyCounter.UpdateMoneyCount();
            }

            foreach (string item in itemsOnStall)
            {
                GameObject itemObject = GameObject.Find(item);
                itemObject.tag = "Untagged";

                if (itemObject.GetComponent<BuyingHandler>())
                {
                    GameObject bag = GameObject.Find(item);
                    SeedBagManager seedBagManager = bag.GetComponent<SeedBagManager>();
                    bag.GetComponent<BuyingHandler>().BuyBag(ref seedBagManager.timesUsed, seedBagManager.maxTimesUsed);
                }
            }
            itemsOnStall.Clear();
        }
        CalculatePrice();
        paymentBox.UIEnable(false);
    }
}
