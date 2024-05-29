using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public float moneyNr;
    private string moneyText;

    // update amount of money every frame
    void Update()
    {
        // converts int to string
        moneyText = moneyNr.ToString();

        // writes text on money ui
        gameObject.GetComponent<Text>().text = moneyText;
    }
}
