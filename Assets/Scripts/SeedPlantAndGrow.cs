using UnityEngine;
using UnityEngine.Events;

public class SeedInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    public GameObject WheatSmall; // Reference to the wheat prefab
    private void OnTriggerEnter(Collider other)
    {
        // Check if the seed touches the dirt
        if (other.CompareTag("TilledDirt"))
        {
            // Spawn wheat at specific locations on the dirt
            onTriggerEnter.Invoke();
            SpawnWheat(other.transform);
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
