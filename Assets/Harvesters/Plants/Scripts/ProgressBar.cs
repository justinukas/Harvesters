using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject vitalijusBar;

    // clone the progress bar if its not there already
    public void CloneBar(Transform plantParentTransform)
    {
        if (plantParentTransform.parent.Find("VitalijusBar") == false)
        {
            GameObject VitalijusbarClone = Instantiate(vitalijusBar, new Vector3(plantParentTransform.position.x, 1, plantParentTransform.position.z), Quaternion.identity, plantParentTransform.parent);
            VitalijusbarClone.name = "VitalijusBar";
        }
    }

    // progress the bar based on the current and max height of a plant
    public void BarProgress(Transform plantParentTransform, float fullgrowth)
    {
        if (plantParentTransform.parent.Find("VitalijusBar") == true)
        {
            float progressing;
            progressing = plantParentTransform.position.y / fullgrowth;
            plantParentTransform.parent.Find("VitalijusBar").Find("Slider").GetComponent<Slider>().value = progressing;
        }
        else { return; }
    }
}
