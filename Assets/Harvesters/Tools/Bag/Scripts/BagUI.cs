using System.Collections.Generic;
using UnityEngine;

public class BagUI : MonoBehaviour
{
    [System.Serializable]
    public class PlantUI
    {
        public string plantName;
        public GameObject plantUIElement;
    }

    public List<PlantUI> plantUIList;    

       
    private Dictionary<string, GameObject> plantUIDictionary;

     
    private void Start()
    {
        plantUIDictionary = new Dictionary<string, GameObject>();
        foreach (var plantUI in plantUIList)
        {
            plantUIDictionary[plantUI.plantName] = plantUI.plantUIElement;
        }
    }

    public void SpawnUI(string plant)
    {
        if (plantUIDictionary.TryGetValue(plant, out GameObject plantCounter))  
        {
            if (!plantCounter.activeInHierarchy)
            {
                plantCounter.SetActive(true);
            }
        }
    }

    public void DisableAllUIElements()
    {
        foreach (GameObject uiElement in plantUIDictionary.Values)
        {
            uiElement.SetActive(false);
        }
    }
}
