using UnityEngine;

public class Darkness : MonoBehaviour
{
    public Light directionalLight;

    bool playerCollided = false;
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
        if (playerCollided && directionalLight.GetComponent<Light>().intensity > 0)
        {
            directionalLight.GetComponent<Light>().intensity -= Time.deltaTime / 2;
        }
        if (playerCollided == false && directionalLight.GetComponent<Light>().intensity <= 1)
        {
            directionalLight.GetComponent<Light>().intensity += Time.deltaTime / 2;
        }
    }
}
