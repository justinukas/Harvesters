using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    [HideInInspector] public float moneyNr;
    private string moneyText;

    private void Start()
    {
        moneyNr = 100;
        UpdateMoneyCount();
    }

    public void UpdateMoneyCount()
    {
        // converts int to string
        moneyText = moneyNr.ToString();

        // writes text on money ui
        gameObject.GetComponent<Text>().text = moneyText;
    }
}
