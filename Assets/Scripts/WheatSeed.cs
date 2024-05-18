using UnityEngine;
using System.Collections.Generic;

public class WheatSeed : MonoBehaviour
{
    public GameObject WheatSmall; // Reference to the wheat prefab

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

            gameObject.GetComponent<AudioSource>().Play(); // play the planting sfx
            
            if (plantingEnablerScript.plantingAllowed)
            {
                PositionList(); // initiate wheat position listing 
            }
        }
    }

    // make a list
    private List<Vector3> wheatPositionsList = new List<Vector3>();
    // add a 5x5 vector3 grid to list
    private void PositionList()
    {
        float wheatSpawnOffsetX = 0.4f;
        float wheatSpawnOffsetZ = 0.45f;
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                wheatPositionsList.Add(new Vector3(wheatSpawnOffsetX, 0.3f, wheatSpawnOffsetZ));
                wheatSpawnOffsetZ -= 0.2f;
            }
            wheatPositionsList.Add(new Vector3(wheatSpawnOffsetX, 0.3f, wheatSpawnOffsetZ));
            wheatSpawnOffsetX -= 0.2f;
            wheatSpawnOffsetZ = 0.45f;
        }
        SpawnWheat();
        ParticleEmit(); 
        ColorFading();
    }

    // spawns wheat at set positions 
    private void SpawnWheat()
    {

        // Get the top surface position of the dirt
        dirtSurface = dirtPosition + Vector3.up * dirtPosition.y / 2f;

        // Instantiate wheat at fixed locations on the top surface of the dirt
        foreach (Vector3 spawnOffset in wheatPositionsList) 
        {
            Vector3 finalSpawnPosition = dirtSurface + spawnOffset; // calculate final spawn position with an offset from list
            GameObject wheatGameObject = Instantiate(WheatSmall, finalSpawnPosition, Quaternion.Euler(-100, 15, -85)); // instantiate wheat at the calculated position
            wheatGameObject.transform.SetParent(tilledDirt.transform); // sets cloned wheat parent to the tilled dirt
        }
    }

    public ParticleSystem plantParticles;
    private ParticleSystem plantParticlesCopy;

    // emits particles when the wheat is planted
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
