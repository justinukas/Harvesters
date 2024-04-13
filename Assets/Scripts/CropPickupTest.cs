using UnityEngine;
using UnityEngine.Events;

public class CropPickupTest : MonoBehaviour
{
    void Awake()
    {
        enabled = false;
    }
    private void OnEnable()
    {
        Destroy(gameObject);
    }

    /*void OnCollisionEnter(Collision other)
    {
        Debug.Log("what the freak");
        if (other.gameObject.CompareTag("GameController"))
        {
            Debug.Log("OH IM GRABBED!!!");
        }
    }*/
} 