using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System.Collections.Generic;

public class WheatSeedTest : MonoBehaviour
{
    [SerializeField] UnityEvent plantingSFX;

    public GameObject WheatSmall; // Reference to the wheat prefab
    private Vector3 dirtPosition;

    private void OnCollisionEnter(Collision collider)
    {
        // Check if the seed bag is touching the dirt
        if (collider.gameObject.CompareTag("TilledDirt"))
        {
            dirtPosition = collider.gameObject.transform.position; // save position of dirt

            plantingSFX.Invoke(); // play the planting sfx

            PositionList(); // initiate wheat position list

            Destroy(gameObject); // destroy seed bag
        }
    }

    // make a list
    private List<Vector3> wheatPositionsList = new List<Vector3>();

    // add a 5x5 vector3 grid to list
    private void PositionList()
    {
        float wheatSpawnOffsetX = 0.5f;
        float wheatSpawnOffsetZ = 0.45f;
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                wheatPositionsList.Add(new Vector3(wheatSpawnOffsetX, 0.5f, wheatSpawnOffsetZ));
                wheatSpawnOffsetZ -= 0.2f;
            }
            wheatPositionsList.Add(new Vector3(wheatSpawnOffsetX, 0.5f, wheatSpawnOffsetZ));
            wheatSpawnOffsetX -= 0.2f;
            wheatSpawnOffsetZ = 0.45f;
        }
        SpawnWheat();
    }

    private void SpawnWheat()
    {
        // Get the top surface position of the dirt
        Vector3 dirtSurface = dirtPosition + Vector3.up * dirtPosition.y / 2f;
        Debug.Log(dirtSurface);

        List<GameObject> Wheat = new List<GameObject>();
        // Instantiate wheat at fixed locations on the top surface of the dirt
        foreach (Vector3 spawnOffset in wheatPositionsList) 
        {
            Vector3 finalSpawnPosition = dirtSurface + spawnOffset; // calculate final spawn position with an offset from list
            Wheat.Add(Instantiate(WheatSmall, finalSpawnPosition, Quaternion.Euler(-90f, 0f, 0f))); // instantiate wheat at the calculated position
            Debug.Log(Wheat.name);
        }
    }
}
