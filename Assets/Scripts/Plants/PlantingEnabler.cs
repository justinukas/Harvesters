using UnityEngine;
using System.Collections.Generic;

public class PlantingEnabler : MonoBehaviour
{
    public bool plantingAllowed = true;

    void Update()
    {
        if (transform.childCount > 0)
        {
            plantingAllowed = false;
        }
        
        if (transform.childCount <= 0)
        {
            plantingAllowed = true;
        }
    }   
}
