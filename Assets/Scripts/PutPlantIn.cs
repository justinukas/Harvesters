using UnityEngine;
using UnityEngine.UI;

public class PutPlantIn : MonoBehaviour
{
    //inventory gameobject
    private GameObject inventory;

    // gameobjects
    private GameObject closedBag;
    private GameObject openBag;

    // text fields 4 crops
    private GameObject carrotTextGO;
    private GameObject wheatTextGO;

    // crops
    int carrotNr = 0;
    string carrotNrText;
    int wheatNr = 0;
    string wheatNrText;

    // money related
    int weight = 20;
    int value; // value = 2x weight
    //payout = weight*2 (1 weight = 2 dabloons)
    
    void Start()
    {
        // gets needed objects from scenes
        openBag = GameObject.Find("Open Bag");
        closedBag = GameObject.Find("Closed Bag");
        inventory = GameObject.Find("Inventory");

        // hides closed bag
        closedBag.transform.position = new Vector3(0f, 0f, 0f);
    }
    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("collided");
        if (collider.gameObject.CompareTag("Wheat"))
        {
            wheatNr = wheatNr + 1;
            wheatNrText = wheatNr.ToString();

            wheatTextGO = GameObject.Find("Wheat Nr");
            wheatTextGO.GetComponent<Text>().text = wheatNrText;

            weight = weight + 1;
            Destroy(collider.gameObject);

           
        }
        if (collider.gameObject.CompareTag("Carrot"))
        {
            Debug.Log("collider is carrot");
            carrotNr = carrotNr + 1;
            carrotNrText = carrotNr.ToString();

            carrotTextGO = GameObject.Find("Carrot Nr");
            carrotTextGO.GetComponent<Text>().text = carrotNrText;

            weight = weight + 2;
            Destroy(collider.gameObject);
        }
       
    }

    //closes bag when full
    void Update()
    {
        if (weight >= 20)
        {
            //resets closed bag momentum
            closedBag.GetComponent<Rigidbody>().isKinematic = true;
            closedBag.GetComponent<Rigidbody>().isKinematic = false;

            //teleports closed bag to open bag
            closedBag.transform.position = new Vector3(openBag.transform.position.x, openBag.transform.position.y - 0.3f, openBag.transform.position.z);

            //makes the closed bag the inventory canvas' parent
            inventory.transform.SetParent(closedBag.transform);

            //hides open bag
            openBag.transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}


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
//spargalke for when the eats are sold
*/