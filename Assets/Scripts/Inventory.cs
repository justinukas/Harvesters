using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //inventory gameobject
    private GameObject inventory;

    // bag variants
    private GameObject closedBag;
    private GameObject openBag;

    // text fields on canvas for crops
    private GameObject carrotTextGO;
    private GameObject wheatTextGO;

    // crops
    int carrotNr = 0;
    string carrotNrText;
    int wheatNr = 0;
    string wheatNrText;

    // money related
    float value; // value = 2x weight (1 weight = 2 dabloons)

    // fullness measurement
    float weight = 0f;

    public bool bagIsActive = true;
    
    void Start()
    {
        // gets needed objects from scenes
        openBag = GameObject.Find("Open Bag");
        closedBag = GameObject.Find("Closed Bag");
        inventory = GameObject.Find("Inventory");

        // hides closed bag
        closedBag.transform.position = new Vector3(0f, 0f, 0f);
    }

    // for putting things in bag
    void OnCollisionEnter(Collision collider)
    {
        if (bagIsActive && collider.gameObject.CompareTag("Carrot"))
        {
            carrotNr = carrotNr + 1;
            carrotNrText = carrotNr.ToString();

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
            wheatNr = wheatNr + 1;

            //converts int to string
            wheatNrText = wheatNr.ToString();

            //finds wheatnr textbox and writes number of wheat in it
            wheatTextGO = GameObject.Find("Wheat Nr");
            wheatTextGO.GetComponent<Text>().text = wheatNrText;

            weight = weight + 0.5f;
            Closing();
        }
        
    }

    // function for closing the bag
    void Closing()
    {
        // close bag when its full
        if (weight >= 20)
        {
            bagIsActive = false;
            //resets closed bag momentum
            closedBag.GetComponent<Rigidbody>().isKinematic = true;
            closedBag.GetComponent<Rigidbody>().isKinematic = false;

            //teleports closed bag to open bag
            closedBag.transform.position = new Vector3(openBag.transform.position.x, openBag.transform.position.y - 0.3f, openBag.transform.position.z);

            //makes the closed bag the inventory canvas' parent
            inventory.transform.SetParent(closedBag.transform);

            //hides open bag
            openBag.transform.position = new Vector3(0f, 0f, 0f);
            value = weight * 2;
            weight = 0;
        }
    }
}


// this script should probably be on the "Inventory" canvas instead of Open Bag but idk it might not matter

//spargalke for when the eats are sold
/*        
    //resets open bag momentum
    openBag.GetComponent<Rigidbody>().isKinematic = true;
    openBag.GetComponent<Rigidbody>().isKinematic = false;

    //teleports open bag to open bag
    openBag.transform.position = new Vector3(closedBag.transform.position.x, closedBag.transform.position.y, closedBag.transform.position.z);

    //makes the open bag the inventory canvas' parent
    inventory.transform.SetParent(openBag.transform);

    //hides closed bag
    closedBag.transform.position = new Vector3(0f, 0f, 0f);
*/
