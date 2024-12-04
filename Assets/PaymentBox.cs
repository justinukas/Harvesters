using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaymentBox : MonoBehaviour
{
    [SerializeField] private BuyingStall buyingStall;

    bool armInBox = false;

    Text textObject;

    int remainingPrice;

    private void Start()
    {
        textObject = transform.Find("UI").Find("Text").GetComponent<Text>();
        UIEnable(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Money Arm" && buyingStall.itemsOnStall.Count > 0)
        {
            armInBox = true;
            remainingPrice = buyingStall.price;
            StartCoroutine(DecreaseUIIntValue());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Money Arm")
        {
            armInBox = false;
            remainingPrice = buyingStall.price;
        }
    }

    public void UIEnable(bool enabled)
    {
        if (enabled)
        {
            textObject.gameObject.SetActive(true);
            remainingPrice = buyingStall.price;
            textObject.text = remainingPrice.ToString();
        }
        else if (!enabled)
        {
            textObject.gameObject.SetActive(false);
            textObject.text = "0";
        }
    }

    private IEnumerator DecreaseUIIntValue()
    {
        while (remainingPrice > 0 && armInBox == true)
        {
            remainingPrice--;
            textObject.text = remainingPrice.ToString();
            yield return new WaitForSeconds(remainingPrice / buyingStall.price);
        }

        if (remainingPrice == 0)
        {
            yield return new WaitForSeconds(2);
            textObject.text = "0";
            UIEnable(false);

            // play sfx and some kind of vfx maybe
            buyingStall.BuyItem();
        }
    }
}
