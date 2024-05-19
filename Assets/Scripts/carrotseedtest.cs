using UnityEngine;
using System.Collections.Generic;

public class CarrotSeed : MonoBehaviour
{
    public GameObject Carrot; // Reference to the carrot prefab

    private GameObject tilledDirt; 
    private PlantingEnabler plantingEnablerScript;
        
    private Vector3 dirtPosition;
    private Vector3 dirtSurface;

    private void OnCollisionEnter(Collision collider)
    {
        // Check if the seed bag is touching the dirt
        if (collider.gameObject.CompareTag("TilledDirt"))
        {
            plantingEnablerScript = collider.gameObject.GetComponent<PlantingEnabler>(); // get the planting enabler script from tilled dirt gameobject

            tilledDirt = collider.gameObject; // save gameobject of dirt

            dirtPosition = collider.gameObject.transform.position; // save position of dirt
            
            if (plantingEnablerScript.plantingAllowed)
            {
                gameObject.GetComponent<AudioSource>().Play(); // play the planting sfx
                SpawnCarrot();
                ParticleEmit();
                ColorFading();
            }
        }
    }

    // make a list for carrot positions
    private Vector3[] carrotPositions = new Vector3[]
    {
            new Vector3(-0.4f, 0.22f, -0.4f), //bottom right
            new Vector3(0f, 0.22f, -0.4f), //middle right
            new Vector3(0f, 0.22f, -0.05f), //middle
            new Vector3(0f, 0.22f, 0.3f), //middle left
            new Vector3(0.4f, 0.22f, -0.4f), //top right
            new Vector3(-0.4f, 0.22f, 0.3f), //bottom left
            new Vector3(0.4f, 0.22f, 0.3f), //top right
            new Vector3(0.4f, 0.22f, -0.05f), //middle top
            new Vector3(-0.4f, 0.22f, -0.05f), //middle bottom
    };
    
    // spawns carrot at set positions 
    private void SpawnCarrot()
    {
        // Get the top surface position of the dirt
        dirtSurface = dirtPosition + Vector3.up * dirtPosition.y / 2f;

        // Instantiate carrot at fixed locations on the top surface of the dirt
        foreach (Vector3 spawnOffset in carrotPositions) 
        {
            Vector3 finalSpawnPosition = dirtSurface + spawnOffset; // calculate final spawn position with an offset from list
            GameObject carrotGameObject = Instantiate(Carrot, finalSpawnPosition, Quaternion.identity); // instantiate carrot at the calculated position
            carrotGameObject.transform.SetParent(tilledDirt.transform); // sets cloned carrot parent to the tilled dirt
        }
    }

    public ParticleSystem plantParticles;
    private ParticleSystem plantParticlesCopy;

    // emits particles when the carrot is planted
    private void ParticleEmit()
    {
        plantParticlesCopy = Instantiate(plantParticles, dirtSurface, Quaternion.identity);
        plantParticlesCopy.transform.position = new Vector3(dirtSurface.x, dirtSurface.y+0.45f, dirtSurface.z);
        plantParticlesCopy.Emit(10);
        plantParticlesCopy.Stop();
    }

    public GameObject bagTop;
    public GameObject bagBottom;
    float r = 0.0549f;
    // fades color of bag to indicate uses left
    public void ColorFading()
    {
        if (r <= 0.509804)
        {
            bagTop.GetComponent<Renderer>().material.color = new Color(r += 0.0454904f, 0.396f, 0.0666f);
            bagBottom.GetComponent<Renderer>().material.color = new Color(r += 0.0454904f, 0.396f, 0.0666f);
        }
        else Invoke("SeedDestruction", 3);
    }

    //destroys seed bag
    void SeedDestruction()
    {
        Destroy(gameObject);
    }
}
