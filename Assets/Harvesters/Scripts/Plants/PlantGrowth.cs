using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CHATGPT COMING IN CLUTCH WITH THIS. LET IT COOK NOW
public class PlantGrowth : MonoBehaviour
{
    [HideInInspector] public float growthRate = 0.01f;
    private Transform plantParentTransform;

    private Dictionary<string, (float MaxHeight, Color? GrownColor, string ChildName)> plantTypes;
    private void Start()
    {
        InitializePlantTypes();
        StartCoroutine(GrowPlants());
    }

    private void InitializePlantTypes()
    {
        plantTypes = new Dictionary<string, (float MaxHeight, Color? GrownColor, string ChildName)>
            {
                {"WheatParent", (0.629f, new Color(0.9960784f, 0.9490196f, 0.5707546f), "Wheat") },
                {"CarrotParent", (0.27f, null, "Carrot") }
                // add new plants here
            };
    }

    private IEnumerator GrowPlants()
    {
        while (true)
        {
            foreach (var plantType in plantTypes)
            {
                foreach (GameObject plantParent in GameObject.FindGameObjectsWithTag(plantType.Key))
                {
                    HandlePlantGrowth(plantParent, plantType.Value);
                }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void HandlePlantGrowth(GameObject plantParent, (float MaxHeight, Color? GrownColor, string ChildName) plantType)
    {
        plantParentTransform = plantParent.transform;
        if (plantParentTransform.position.y < plantType.MaxHeight && plantParentTransform.childCount > 0)
        {
            plantParentTransform.position = plantParentTransform.position + new Vector3(0, Time.deltaTime * growthRate, 0);
        }
        else if (plantParentTransform.position.y >= plantType.MaxHeight)
        {
            Vector3 currentPosition = plantParentTransform.position;
            currentPosition.y = plantType.MaxHeight;
            plantParentTransform.position = currentPosition;
        }

        if (plantParentTransform.position.y >= plantType.MaxHeight && plantParentTransform.childCount > 0)
        {
            foreach (Transform child in plantParent.transform)
            {
                child.GetComponent<Harvestability>().isHarvestable = true;
                if (plantType.GrownColor != null)
                {
                    child.GetComponent<Renderer>().material.color = plantType.GrownColor.Value;
                }
            }
        }
        if (plantParentTransform.childCount == 0) plantParentTransform.position = Vector3.zero;
    }
}
