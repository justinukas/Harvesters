using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// CHATGPT COMING IN CLUTCH WITH THIS. LET IT COOK NOW
public class PlantGrowth : MonoBehaviour
{
    public PlantType[] plantTypes;

    [System.Serializable]
    public class PlantType
    {
        public string tagName;
        public float maxHeight;
        public Color grownColor;
        public bool colorHasValue;
        public string childName;
    }

    private void Start()
    {
        StartCoroutine(GrowPlants());
    }

    private IEnumerator GrowPlants()
    {
        while (true)
        {
            foreach (PlantType plantType in plantTypes)
            {
                GameObject[] plantParents = GameObject.FindGameObjectsWithTag(plantType.tagName);
                foreach (GameObject plantParent in plantParents)
                {
                    Grow(plantParent, plantType);
                }
            }
            yield return new WaitForSeconds(1.0f); // Pause for 1 second before the next growth update
        }
    }

    private void Grow(GameObject plantParent, PlantType plantData)
    {
        Transform plantParentTransform = plantParent.transform;

        // Grow the plant vertically until it reaches max height
        if (plantParentTransform.position.y < plantData.maxHeight && plantParentTransform.childCount > 0)
        {
            plantParentTransform.position += new Vector3(0, plantData.maxHeight / 60f, 0);
            ProgressBar(plantParentTransform,plantData.maxHeight);
        }

        // Ensure plant stays at max height once it reaches it
        else
        {
            plantParentTransform.position = new Vector3(plantParentTransform.position.x, plantData.maxHeight, plantParentTransform.position.z);

            // Make child gameobjects harvestable and apply grown color 
            foreach (Transform child in plantParent.transform)
            {
                MakeHarvestable(child);
                Color(child, plantData.grownColor, plantData.colorHasValue);
               

            }
        }

        // Reset the plant parents if all the plants have been harvested
        if (plantParentTransform.childCount == 0)
        {
            plantParentTransform.position = Vector3.zero;
        }
    }

    // Apply harvestable states
    private void MakeHarvestable(Transform child)
    {
        Harvestability harvestability = child.GetComponent<Harvestability>();
        harvestability.MakeHarvestable();
    }

    // Apply grown color
    private void Color(Transform child, Color? grownColor, bool colorHasValue)
    {
        if (colorHasValue)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            renderer.material.color = grownColor.Value;
        }
    }

    [SerializeField] Slider Vitalijusbar;







    private void ProgressBar (Transform plantParentTransform, float fullgrowth)
    {
        float progressing;
        progressing = plantParentTransform.position.y/fullgrowth;
        Vitalijusbar.value = progressing;
    }
}
