using System.Collections.Generic;
using UnityEngine;

public class PlantSpawningHandler : MonoBehaviour
{
    public void SpawnPlants(string bagVariant, GameObject tilledDirt)
    {
        if (GetComponent<PlantInfoHandler>().plantInfo.TryGetValue(bagVariant, out var info))
        {
            List<Vector3> positions = info.Item1;
            Transform parent = info.Item2;
            GameObject plant = info.Item3;

            foreach (Vector3 spawnOffset in positions)
            {
                GameObject plantClone = Instantiate(plant, spawnOffset + tilledDirt.transform.position, Quaternion.identity, parent);
                plantClone.name = plant.name;
            }
        }
    }
}
