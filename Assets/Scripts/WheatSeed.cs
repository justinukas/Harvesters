using UnityEngine;
using System.Collections.Generic;

public class WheatSeed : MonoBehaviour
{
    float r; // R value for bag color RGB
    int timesUsed = 0; // measurement for bag uses

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
                PositionListing();
            }
        }
    }

    private List<Vector3> wheatPositionsList = new List<Vector3>();
    // make a list for wheat positions for SpawnWheat method
    private void PositionListing()
    {
        float wheatSpawnOffsetX = 0.4f;
        float wheatSpawnOffsetZ = 0.45f;
        for (int LineX = 1; LineX <= 5; LineX++)
        {
            for (int LineZ = 1; LineZ <= 4; LineZ++)
            {
                wheatPositionsList.Add(new Vector3(wheatSpawnOffsetX, 0.3f, wheatSpawnOffsetZ));
                wheatSpawnOffsetZ -= 0.2f;
            }
            wheatPositionsList.Add(new Vector3(wheatSpawnOffsetX, 0.3f, wheatSpawnOffsetZ));
            wheatSpawnOffsetX -= 0.2f;
            wheatSpawnOffsetZ = 0.45f;
        }
        SpawnWheat();
    }

    public GameObject Wheat; // Reference to the wheat prefab
    private Vector3 dirtSurface;

    private void SpawnWheat()
    {
        Vector3 dirtPosition = tilledDirt.transform.position;
        // Get the top surface position of the dirt
        dirtSurface = dirtPosition + Vector3.up * dirtPosition.y / 2f;

        // Instantiate wheat at fixed locations on the top surface of the dirt
        foreach (Vector3 spawnOffset in wheatPositionsList)
        {
            Vector3 finalSpawnPosition = dirtSurface + spawnOffset; // calculate final spawn position with an offset from list
            GameObject wheatGameObject = Instantiate(Wheat, finalSpawnPosition, Quaternion.Euler(-90, 0, 0)); // instantiate wheat at the calculated position
            wheatGameObject.transform.SetParent(tilledDirt.transform); // sets cloned wheat parent to the tilled dirt
        }
        ParticleEmit();
    }

    // reference to particle systems
    public ParticleSystem plantParticles;

    // emits particles when the wheat is planted
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
