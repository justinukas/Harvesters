using UnityEngine;

public class BuyingHandler : MonoBehaviour
{
    public void BuyBag(ref int timesUsed)
    {
        timesUsed = 0;
        GetComponent<ColorHandler>().ChangeBagColor(timesUsed);
    }
}
