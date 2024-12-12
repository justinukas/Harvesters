using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject progressBar;

    // clone the progress bar if its not there already
    public void CloneBar(Transform plantParentTransform)
    {
        if (plantParentTransform.parent.Find("ProgressBar") == false)
        {
            GameObject VitalijusbarClone = Instantiate(progressBar, new Vector3(plantParentTransform.parent.position.x, 1, plantParentTransform.parent.position.z), Quaternion.identity);
            VitalijusbarClone.transform.parent = plantParentTransform.parent;
            VitalijusbarClone.name = "ProgressBar";
        }
    }

    // progress the bar based on the current and max height of a plant
    public void BarProgress(Transform plantParentTransform, float fullgrowth)
    {
        if (plantParentTransform.parent.Find("ProgressBar") == true)
        {
            float progressing;
            progressing = plantParentTransform.position.y / fullgrowth;
            plantParentTransform.parent.Find("ProgressBar").Find("Canvas").Find("Background").Find("Background (1)").GetComponent<Image>().fillAmount = progressing;   
        }
        else { return; }
    }
}
