using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public int MoneyNr;
    string MoneyText;
    void Update()
    {
        MoneyText = MoneyNr.ToString();
        gameObject.GetComponent<Text>().text = MoneyText;
    }
}
