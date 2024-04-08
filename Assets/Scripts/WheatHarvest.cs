using UnityEngine;
using UnityEngine.Events;

public class WheatHarvest : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("WheatSmall"))
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}