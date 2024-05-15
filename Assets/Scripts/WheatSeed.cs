using UnityEngine;
using UnityEngine.Events;

public class SeedInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent PopSFX;

    public GameObject WheatSmall; // Reference to the wheat prefab
    int timesSpawned = 1;
    float wheatSpawnOffsetX;
    float wheatSpawnOffsetZ;

    private void OnCollisionEnter(Collision other)
    {
        // Check if the seed touches the dirt
        if (other.gameObject.CompareTag("TilledDirt"))
        {
            // Spawn wheat at specific locations on the dirt
            PopSFX.Invoke();
            SpawnWheat(other.gameObject.transform);
            Destroy(gameObject);
        }
    }

    private void SpawnWheat(Transform dirtTransform)
    {
        // Get the top surface position of the dirt
        Vector3 spawnPosition = dirtTransform.position + Vector3.up * dirtTransform.localScale.y / 2f;

        // Define fixed spawn positions relative to the top surface of the dirt
        Vector3[] fixedSpawnOffsets = new Vector3[]
        {
        new Vector3(-0.45f, 0.5f, -0.45f),
        new Vector3(0.45f, 0.5f, -0.45f),
        new Vector3(-0.45f, 0.5f, 0.45f),
        new Vector3(0.45f, 0.5f, 0.45f),
        new Vector3(0f, 0.5f, 0f)
        };
        for (timesSpawned = 1; timesSpawned <= 5; timesSpawned++)
        {
            for (timesSpawned = 1; timesSpawned <=5; timesSpawned++)
            {

            }
            float wheatSpawnOffsetX = -0.45f + 0.15f;
            fixedSpawnOffsets.Add(new Vector3(wheatSpawnOffsetX, 0.5f, wheatSpawnOffsetZ));
        }

        // Instantiate wheat at fixed locations on the top surface of the dirt
        foreach (Vector3 offset in fixedSpawnOffsets)
        {
            // Calculate final spawn position with fixed offset
            Vector3 finalSpawnPosition = spawnPosition + offset;

            // Instantiate wheat at the calculated position
            Instantiate(WheatSmall, finalSpawnPosition, Quaternion.identity);
        }
    }

}
