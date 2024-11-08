using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagInventory : MonoBehaviour
{
    [Header("Meshes")]
    [SerializeField] private Mesh closedBagMesh;
    [SerializeField] private Mesh openBagMesh;

    // bag's mesh
    private MeshFilter bagMesh;

    // fullness measurement
    [HideInInspector] public float weight = 0;

    [HideInInspector] public bool isBagOpen;

    private string plant;

    private BagUI bagUI;

    private Dictionary<string, int> plantCounts = new Dictionary<string, int>
    {
        {"Carrot", 0 },
        {"Wheat", 0 },
        {"Apple", 0}
    };
    private Dictionary<string, float> plantWeights = new Dictionary<string, float>
    {
        {"Carrot", 1.0f},
        {"Wheat", 0.5f},
        {"Apple", 3.0f}
    };

    private void Start()
    {
        bagUI = GetComponent<BagUI>();
        bagMesh = transform.GetComponent<MeshFilter>();
        weight = 0;
        isBagOpen = true;
    }

    public void Collection()
    {
        if (isBagOpen)
        {
            bagUI.SpawnUI(plant);

            plantCounts[plant] += 1;

            weight += plantWeights[plant];

            transform.Find("Inventory").Find(plant).GetComponent<Text>().text = plantCounts[plant].ToString();

            CloseBag();
        }
    }

    // put carrot in bag
    private void OnCollisionEnter(Collision collider)
    {
        if (isBagOpen && collider.gameObject.transform.parent == null)
        {
            plant = collider.gameObject.tag;

            if (plantWeights.ContainsKey(plant))
            {
                Collection();
                Destroy(collider.gameObject);
            }
        }
    }

    // close bag
    private void CloseBag()
    {
        // close bag when its full
        if (weight >= 30)
        {
            isBagOpen = false;
            bagMesh.mesh = closedBagMesh;
        }
    }

    // open bag
    public void OpenBag()
    {
        isBagOpen = true;
        bagMesh.mesh = openBagMesh;
        weight = 0f;
    }

    // reset counters and UI on sale
    public void ResetAllCounters()
    {
        OpenBag();
        weight = 0f;

        foreach (string plant in plantCounts.Keys)
        {
            plantCounts[plant] = 0;
            transform.Find("Inventory").Find(plant).GetComponent<Text>().text = "0";
        }

        bagUI.DisableAllUIElements();
    }
}
