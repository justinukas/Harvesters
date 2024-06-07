using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Foggy : MonoBehaviour 
{
    float r;
    float g;
    float b;

    bool playerCollided = false;

    public Light directionalLight;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerCollided = true;       
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerCollided = false;
        }
        
    }

    void Update()
    {
        if (playerCollided == true && RenderSettings.fogDensity < 0.5f)
        {
            RenderSettings.fogDensity += Time.deltaTime / 8;
            r = 0.23f;
            g = 0.23f;
            b = 0.23f;
            RenderSettings.fogColor = new Color(r, g, b);
        }

        if (playerCollided == false)
        {
            if (RenderSettings.fogDensity >= 0.003f)
            {
                RenderSettings.fogDensity -= Time.deltaTime / 8;
            }
            if (RenderSettings.fogDensity <= 0.003f)
            {
                RenderSettings.fogDensity += Time.deltaTime / 8;
            }
            if (r <= 0.9372549f)
            {
                r += Time.deltaTime / 9;
            }
            if (g <= 1f)
            {
                g += Time.deltaTime / 8;
            }
            if (b <= 0.682353)
            {
                b += Time.deltaTime / 12;
            }
            RenderSettings.fogColor = new Color(r, g, b);
        }

        if (playerCollided && directionalLight.intensity > 0)
        {
            directionalLight.intensity -= Time.deltaTime / 2;
        }
        if (playerCollided == false && directionalLight.intensity <= 1)
        {
            directionalLight.intensity += Time.deltaTime / 2;
        }
    }
}
