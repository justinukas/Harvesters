using UnityEngine;
using UnityEngine.UI;

public class ProgressBar2 : MonoBehaviour
{

    private Image image;

    public float Fillspeed = 0.5f;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    //Update is called once per frame
    private void Update()
    { 
        if (image.fillAmount <= 1)
        {
            image.fillAmount += Fillspeed * Time.deltaTime;
        }
    }
}
