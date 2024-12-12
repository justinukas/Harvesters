using UnityEngine;

public class BagUI : MonoBehaviour
{ 
    private Transform plantUiParent;

    private void Start()
    {
        plantUiParent = transform.Find("Inventory");
    }

    public void SpawnUI(string plant)
    {
        if (transform.Find("Inventory").Find(plant))
        {
            GameObject plantUI = transform.Find("Inventory").Find(plant).gameObject;

            if (!plantUI.activeInHierarchy)
            {
                plantUI.SetActive(true);
            }
        }
    }

    public void DisableAllUIElements()
    {
        foreach (Transform plantUiElement in plantUiParent)
        {
            plantUiElement.gameObject.SetActive(false);
        }
    }
}
