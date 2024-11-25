using System.Collections.Generic;
using UnityEngine;

public class BuyingStall : MonoBehaviour
{
    [SerializeField] private MoneyCounter moneyCounter;

    List<string> itemsOnStall = new List<string>();

    int price = 0;

    private void Update()
    {
        if (itemsOnStall.Count > 0)
        {
            Debug.Log(itemsOnStall);
        }
        
    }

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
        Debug.Log(price);
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
                    bag.GetComponent<BuyingHandler>().BuyBag(ref seedBagManager.timesUsed);
                }
            }
            itemsOnStall.Clear();
        }
    }

    private void DisplayPrice()
    {
        // add price display over box
    }

    private void PlayVFX()
    {
        // play vfx
    }
}
