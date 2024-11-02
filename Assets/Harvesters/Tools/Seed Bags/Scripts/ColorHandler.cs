using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    [HideInInspector] public float r;
    private readonly float rFullBag = 0.05490192f;
    private readonly float rDepletedBag = 0.509804f;

    public void SetColor()
    {
        r = rDepletedBag;
        ChangeColor();
    }

    // fades color of bag to indicate uses left
    public void FadeBagColor()
    {
        r += 0.01019608f;
        ChangeColor();
    }

    // change color of bag according to times used
    private void ChangeColor()
    {
        if (r <= rDepletedBag)
        {
            Material[] bagMaterials = gameObject.transform.Find("BagBody").GetComponent<Renderer>().materials;
            bagMaterials[0].color = new Color(r, 0.396f, 0.0666f);
        }
    }

    public void ResetColors()
    {
        r = rFullBag;
        ChangeColor();
    }
}
