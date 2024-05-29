using UnityEngine;
using UnityEngine.UI;

public class BagInventory : MonoBehaviour
{
    // local meshfilter
    private MeshFilter bagMesh;

    // text gameobjects
    private GameObject carrotTextGO;
    private GameObject wheatTextGO;

    private void Start()
    {
        bagMesh = gameObject.GetComponent<MeshFilter>();
        carrotTextGO = GameObject.Find("Carrot Nr");
        wheatTextGO = GameObject.Find("Wheat Nr");
    }

    // bag variant meshes
    public Mesh closedBagMesh;
    public Mesh openBagMesh;

    // crops
    int carrotNr = 0;
    int wheatNr = 0;

    // fullness measurement
    public float weight = 0f;

    // money related
    public float value = 0f;

    public bool bagIsOpen = true;
    
    // put carrots in bag
    void OnCollisionEnter(Collision collider)
    {
        if (bagIsOpen && collider.gameObject.CompareTag("Carrot") && collider.gameObject.transform.parent == null)
        {
            carrotNr += 1;
            string carrotNrText = carrotNr.ToString();

            carrotTextGO = GameObject.Find("Carrot Nr");
            carrotTextGO.GetComponent<Text>().text = carrotNrText;

            weight += 1f;
            Destroy(collider.gameObject);
            Closing();
        }

    }

    // wheat collection
    public void WheatCollection()
    {
        if (bagIsOpen)
        {
            wheatNr += 1;

            //converts int to string
            string wheatNrText = wheatNr.ToString();

            //writes number of wheat
            wheatTextGO.GetComponent<Text>().text = wheatNrText;

            weight += 0.5f;
            Closing();
        }   
    }

    // close bag
    void Closing()
    {
        // close bag when its full
        if (weight >= 20)
        {
            bagIsOpen = false;
            bagMesh.mesh = closedBagMesh;
            gameObject.tag = "Closed Bag";

            value = weight * 2;
            weight = 0f;
        }
    }

    // open bag
    public void Opening()
    {
        bagIsOpen = true;
        bagMesh.mesh = openBagMesh;
        gameObject.tag = "Open Bag";
    }

    // reset counters on sale
    public void Sell()
    {
        Opening();
        value = 0f;
        weight = 0f;
        carrotNr = 0;
        wheatNr = 0;
        carrotTextGO.GetComponent<Text>().text = "0";
        wheatTextGO.GetComponent<Text>().text = "0";
    }
}
