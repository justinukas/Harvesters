using UnityEngine;
using UnityEngine.UI;

public class OpenBagInventory : MonoBehaviour
{
    // bag variants
    private GameObject closedBag;
    private GameObject openBag;
    // inventory canvas
    private GameObject inventory;

    // text gameobjects
    private GameObject carrotTextGO;
    private GameObject wheatTextGO;

    // crops
    int carrotNr = 0;
    int wheatNr = 0;

    // fullness measurement
    float weight = 0f;

    // money related
    float value;

    public bool bagIsActive = true;
    
    void Start()
    {
        // gets needed objects from scenes
        openBag = GameObject.Find("Open Bag");
        closedBag = GameObject.Find("Closed Bag");
        inventory = GameObject.Find("Inventory");
    }

    // put carrots in bag
    void OnCollisionEnter(Collision collider)
    {
        if (bagIsActive && collider.gameObject.CompareTag("Carrot"))
        {
            carrotNr += 1;
            string carrotNrText = carrotNr.ToString();

            carrotTextGO = GameObject.Find("Carrot Nr");
            carrotTextGO.GetComponent<Text>().text = carrotNrText;

            weight = weight + 2f;
            Destroy(collider.gameObject);
            Closing();
        }

    }

    // wheat collection
    public void WheatCollection()
    {
        if (bagIsActive)
        {
            wheatNr += 1;

            //converts int to string
            string wheatNrText = wheatNr.ToString();

            //finds wheatnr textbox and writes number of wheat in it
            GameObject wheatTextGO = GameObject.Find("Wheat Nr");
            wheatTextGO.GetComponent<Text>().text = wheatNrText;

            weight = weight + 0.5f;
            Closing();
        }
        
    }

    // close bag
    void Closing()
    {
        // close bag when its full
        if (weight >= 20)
        {
            bagIsActive = false;

            // *unkinematics your bag*
            closedBag.GetComponent<Rigidbody>().isKinematic = false;

            // teleports closed bag to open bag
            closedBag.transform.position = new Vector3(openBag.transform.position.x, openBag.transform.position.y - 0.3f, openBag.transform.position.z);

            // makes the closed bag the inventory canvas' parent
            inventory.transform.SetParent(closedBag.transform);

            // hides open bag
            openBag.transform.position = new Vector3(0f, 0f, 0f);
            openBag.GetComponent<Rigidbody>().isKinematic = true;

            value = weight * 2f;
            weight = 0f;
        }
    }

    // reset counters on sale
    public void Sell()
    {
        Opening();
        carrotTextGO.GetComponent<Text>().text = "0";
        wheatTextGO.GetComponent<Text>().text = "0";
    }

    // open bag
    void Opening()
    {
        bagIsActive = true;
        
        // unkinematic open bag
        openBag.GetComponent<Rigidbody>().isKinematic = false;
        // teleport open bag to closed bag
        openBag.transform.position = new Vector3(openBag.transform.position.x, openBag.transform.position.y + 0.3f, openBag.transform.position.z);

        // makes open bag inventory canvas' parent
        inventory.transform.SetParent(closedBag.transform);
        // hides closed bag
        closedBag.transform.position = new Vector3(0f, 0f, 0f);
        closedBag.GetComponent<Rigidbody>().isKinematic = true;
    }
}
