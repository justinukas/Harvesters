using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    [SerializeField] Gradient bagColor;

    // fades color of bag to indicate uses left
    public void ChangeBagColor(int timesUsed, int maxTimesUsed)
    {
        Material[] bagMaterials = gameObject.transform.Find("BagBody").GetComponent<Renderer>().materials;
        bagMaterials[0].color = bagColor.Evaluate(timesUsed / maxTimesUsed);
    }
}
