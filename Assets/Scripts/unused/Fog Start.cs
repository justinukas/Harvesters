using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Foggy : MonoBehaviour {
    /*float min = 0.003F;
    float max = 0.25F;
    float t = 0.001F;*/
    float r;
    float g;
    float b;
    bool playerCollided = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerCollided = true;
               // RenderSettings.fogDensity += 2f * Time.deltaTime;
            
          //  RenderSettings.fogDensity = Mathf.Lerp(min, max, t);
        
        }
    }
    void onTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerCollided = false;
        }
        
    }

    void Update() 
    {
        if (playerCollided && RenderSettings.fogDensity < 0.5f)
        {
            RenderSettings.fogDensity += Time.deltaTime/8;
            r = 0.23f;
            g = 0.23f;
            b = 0.23f;
            RenderSettings.fogColor = new Color(r, g, b);
        }
        if (playerCollided == false && RenderSettings.fogDensity >= 0f && r <= 0.937f && g <= 1f && b <= 0.682)
        {
            Debug.Log("decreasing fog");
            RenderSettings.fogDensity -= Time.deltaTime / 8;
            r += Time.deltaTime / 8;
            g += Time.deltaTime / 8;
            b += Time.deltaTime / 8;
            RenderSettings.fogColor = new Color(r, g, b);
        }
    }
}
