using UnityEngine;
using UnityEngine.Events;

public class Tilling : MonoBehaviour
{
    public Rigidbody tilledDirt;
    public Transform dirt;

    void OnTriggerEnter(Collider collidedObject)
    {
        if (/* objectisgrabbed && */collidedObject.CompareTag("Dirt"))
        {
            Instantiate(tilledDirt, collidedObject.transform.position, collidedObject.transform.rotation);
            Destroy(collidedObject.gameObject);
        }
    }
}