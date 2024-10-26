using UnityEngine;
using UnityEngine.UI;

public class BagInventory : MonoBehaviour
{
    [Header("Counters")]
    [SerializeField] private GameObject carrotCounter;
    [SerializeField] private GameObject wheatCounter;

    [Header("Meshes")]
    [SerializeField] private Mesh closedBagMesh;
    [SerializeField] private Mesh openBagMesh;

    // bag's mesh
    private MeshFilter bagMesh;

    // crop counters
    private int carrotCount = 0;
    private int wheatCount = 0;

    // fullness measurement
    [HideInInspector] public float weight = 0;


    [HideInInspector] public bool isBagOpen;

    private BagUI bagUI;


    private void Start()
    {
        bagUI = GetComponent<BagUI>();
        bagMesh = transform.GetComponent<MeshFilter>();
        weight = 0;
        isBagOpen = true;
    }

    // put carrot in bag
    private void OnCollisionEnter(Collision collider)
    {
        if (isBagOpen && collider.gameObject.CompareTag("Carrot") && collider.gameObject.transform.parent == null)
        {
            string plant = "Carrot";
            bagUI.SpawnUI(plant);

            carrotCount += 1;
            string carrotCounterText = carrotCount.ToString();

            carrotCounter.GetComponent<Text>().text = carrotCounterText;

            weight += 1f;

            Destroy(collider.gameObject); // destroy carrot
            CloseBag();
        }
    }

    // wheat collection
    public void WheatCollection()
    {
        if (isBagOpen)
        {
            string plant = "Wheat";
            bagUI.SpawnUI(plant);

            wheatCount += 1;

            //converts int to string
            string wheatNrText = wheatCount.ToString();

            //writes number of wheat
            wheatCounter.GetComponent<Text>().text = wheatNrText;

            weight += 0.5f;
            CloseBag();
        }
    }

    // close bag
    private void CloseBag()
    {
        // close bag when its full
        if (weight >= 20)
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
        carrotCount = 0;
        wheatCount = 0;
        carrotCounter.GetComponent<Text>().text = "0";
        wheatCounter.GetComponent<Text>().text = "0";

        bagUI.DisableAllUIElements();
    }
}
