using UnityEngine;
using System.Collections.Generic;

public class PlantingEnabler : MonoBehaviour
{
    public bool plantingAllowed = true;

    //private Array<Transform> dirtChildrenPlants = new List<Transform>();

    void Update()
    {
        if (transform.childCount > 0)
        {
            plantingAllowed = false;
        }
        else plantingAllowed = true;
        
    }   
}
