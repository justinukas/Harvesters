using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatGrowth : MonoBehaviour
{
    public bool isHarvestable = false;

    float growthRate = 0.39375f;

    void Update()
    {
        if (gameObject.transform.position.y <= 0.94f)
        {
            isHarvestable = false;
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime * growthRate)/120, transform.position.z);
        }

        if (gameObject.transform.position.y >= 0.94f)
        {
            isHarvestable = true;
        }
    }
}
