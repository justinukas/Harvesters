using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Foggy : MonoBehaviour {
    float min = 0.003F;
    float max = 0.025F;
    float t = 0.001F;

void OnTriggerEnter(Collider collider)
    {
        Debug.Log("TriggerEnter");
        if (collider.gameObject.tag == "Player")
        {
            RenderSettings.fogDensity = Mathf.Lerp(min, max, t);
        
        }
    }
    void onTriggerExit(Collider collider)
    {
        Debug.Log("TriggerExit");
        RenderSettings.fogDensity = Mathf.Lerp(max, min, t);
    }
}
