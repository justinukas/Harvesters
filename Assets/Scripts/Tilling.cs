using UnityEngine;
using UnityEngine.Events;

public class Tilling : MonoBehaviour
{
    public Rigidbody tilledDirt;
    public Transform dirt;

    void Start()
    {
        gameObject.GetComponent<Tilling>().enabled = false;
    }

    void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.CompareTag("Dirt") && gameObject.GetComponent<Tilling>().enabled == true)
        {
            Instantiate(tilledDirt, collidedObject.transform.position, collidedObject.transform.rotation); //clones a tilled dirt where the grass is
            Destroy(collidedObject.gameObject); //destroys grass
        }
    }


}