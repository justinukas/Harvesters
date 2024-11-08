using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    [HideInInspector] public float moneyNr;

    private void Start()
    {
        moneyNr = 100;
        UpdateMoneyCount();
    }

    public void UpdateMoneyCount()
    {
        // converts int moneyNr to a string value writes text on money ui
        gameObject.GetComponent<Text>().text = moneyNr.ToString();
    }
}
