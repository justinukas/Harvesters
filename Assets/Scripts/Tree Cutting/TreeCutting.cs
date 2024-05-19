using UnityEngine;
using UnityEngine.Events;

public class TreeCutting : MonoBehaviour
{
    float cooldownInterval; // shit for cutting cooldown
    private float cooldown; // shit for cutting cooldown

    private TimesCut counterScript;

    private GameObject theTree;

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Tree") && Time.time > cooldown)
        {
            cooldown = Time.time + cooldownInterval;

            theTree = collider.gameObject;

            counterScript = theTree.GetComponent<TimesCut>();
            
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponentInChildren<ParticleSystem>().Emit(20);

            counterScript.timesCut += 1;
            if (counterScript.timesCut >= 3)
            {
                theTree.tag = "CutTree";

                theTree.GetComponent<Rigidbody>().isKinematic = false;
                theTree.GetComponent<Rigidbody>().AddForce(transform.position.x + 4f, transform.position.y + 4f, transform.position.z + 4f);
                Invoke("destroyHisBalls", 5);
            }
        }
    }
    void destroyHisBalls()
    {
        Destroy(theTree);
    }
}
