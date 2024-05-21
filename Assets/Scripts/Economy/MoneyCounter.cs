using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public float moneyNr;
    private string moneyText;
    void Update()
    {
        moneyText = moneyNr.ToString();
        gameObject.GetComponent<Text>().text = moneyText;
    }
}
