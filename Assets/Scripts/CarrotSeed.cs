using UnityEngine;
using System.Collections.Generic;

public class CarrotSeed : MonoBehaviour
{
    float r; // R value for bag color RGB
    public int timesUsed = 0; // measurement for bag uses

    // renders bag unusable on game start
    void Start()
    {
        timesUsed = 11; 
        r = 0.509804f; // sets r to final value
    }

    public void Bought()
    {
        timesUsed = 0;
        r = 0.0549f; // sets r to starter value
    }

    private GameObject tilledDirt;
    private void OnCollisionEnter(Collision collider)
    {
        // Check if the seed bag is touching the dirt
        if (collider.gameObject.CompareTag("TilledDirt"))
        {
            // save gameobject of dirt
            tilledDirt = collider.gameObject;

            // get the planting enabler script from tilled dirt gameobject
            PlantingEnabler plantingEnablerScript = collider.gameObject.GetComponent<PlantingEnabler>();

            // check if planting is allowed and if timesUsed doesnt exceed 10
            if (plantingEnablerScript.plantingAllowed == true && timesUsed <= 10)
            {
                timesUsed += 1;
                SpawnCarrot();
            }
        }
    }

    // make a list for carrot positions for SpawnCarrot method
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

    private Vector3 dirtSurface;
    public GameObject Carrot; // Reference to the carrot prefab

    private void SpawnCarrot()
    {
        Vector3 dirtPosition = tilledDirt.transform.position;
        // Get the top surface position of the dirt
        dirtSurface = dirtPosition + Vector3.up * dirtPosition.y / 2f;

        // Instantiate carrot at fixed locations on the top surface of the dirt
        foreach (Vector3 spawnOffset in carrotPositions)
        {
            Vector3 finalSpawnPosition = dirtSurface + spawnOffset; // calculate final spawn position with an offset from list
            GameObject carrotGameObject = Instantiate(Carrot, finalSpawnPosition, Quaternion.identity); // instantiate carrot at the calculated position
            carrotGameObject.transform.SetParent(tilledDirt.transform); // sets cloned carrot parent to the tilled dirt
        }
        ParticleEmit();
    }

    // reference to particle systems
    public ParticleSystem plantParticles;

    // emits particles when the carrot is planted
    private void ParticleEmit()
    {
        ParticleSystem plantParticlesCopy = Instantiate(plantParticles, dirtSurface, Quaternion.identity);

        plantParticlesCopy.transform.position = new Vector3(dirtSurface.x, dirtSurface.y + 0.45f, dirtSurface.z);

        plantParticlesCopy.Emit(10);
        plantParticlesCopy.Stop();
        SFX();
    }

    //play planting sfx
    private void SFX()
    {
        gameObject.GetComponent<AudioSource>().Play();
        ColorFading();
    }

    public GameObject bagTop;
    public GameObject bagBottom;

    // fades color of bag to indicate uses left
    private void ColorFading()
    {
        r += 0.0454904f;
    }

    // updates wheatseed color every frame
    private void Update()
    {
        bagTop.GetComponent<Renderer>().material.color = new Color(r, 0.396f, 0.0666f);
        bagBottom.GetComponent<Renderer>().material.color = new Color(r, 0.396f, 0.0666f);
    }
}
