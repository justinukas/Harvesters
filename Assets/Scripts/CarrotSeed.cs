using UnityEngine;
using UnityEngine.Events;

public class CarrotSeedInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    public GameObject Carrot; // Reference to the carrot prefab
    private void OnCollisionEnter(Collision other)
    {
        // Check if the seed touches the dirt
        if (other.gameObject.CompareTag("TilledDirt"))
        {
            SpawnCarrots(other.gameObject.transform);
            Destroy(gameObject);
        }
    }

    private void SpawnCarrots(Transform dirtTransform)
    {
        // Get the top surface position of the dirt
        Vector3 spawnPosition = dirtTransform.position + Vector3.up * dirtTransform.localScale.y / 2f;

        // Define fixed spawn positions relative to the top surface of the dirt
        Vector3[] fixedSpawnOffsets = new Vector3[]
        {
            new Vector3(-0.4f, -0.2f, -0.4f), //bottom right
            new Vector3(0f, -0.2f, -0.4f), //middle right
            new Vector3(0f, -0.2f, -0.05f), //middle
            new Vector3(0f, -0.2f, 0.3f), //middle left
            new Vector3(0.4f, -0.2f, -0.4f), //top right
            new Vector3(-0.4f, -0.2f, 0.3f), //bottom left
            new Vector3(0.4f, -0.2f, 0.3f), //top right
            new Vector3(0.4f, -0.2f, -0.05f), //middle top
            new Vector3(-0.4f, -0.2f, -0.05f), //middle bottom
        };

        // Instantiate carrots at fixed locations on the top surface of the dirt
        foreach (Vector3 offset in fixedSpawnOffsets)
        {
            // Calculate final spawn position with fixed offset
            Vector3 finalSpawnPosition = spawnPosition + offset;

            // Instantiate wheat at the calculated position
            Instantiate(Carrot, finalSpawnPosition, Quaternion.identity);
        }
    }

}
