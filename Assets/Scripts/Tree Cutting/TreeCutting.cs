using UnityEngine;
using UnityEngine.Events;

public class TreeCutting : MonoBehaviour
{
    private float cooldown = 0.5f;

    // cooldown timer method
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private GameObject theTree;
    public bool canCut = true;

    private void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint contactPoint in collider.contacts) // this foreach is for checking if the collider colliding is the one of the axe's head
        {
            if (collider.gameObject.CompareTag("Tree") && cooldown <= 0 && canCut == true && contactPoint.thisCollider.gameObject.name == "Cube")
            {
                canCut = false;
                cooldown = 1f; // reset cooldown timer

                theTree = collider.gameObject;

                TimesCut counterScript = theTree.GetComponent<TimesCut>();
                TreeDestruction destructionScript = theTree.GetComponent<TreeDestruction>();

                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponentInChildren<ParticleSystem>().Emit(20);

                counterScript.timesCut += 1;
                if (counterScript.timesCut >= 3)
                {
                    theTree.tag = "CutTree";

                    theTree.GetComponent<Rigidbody>().isKinematic = false;
                    theTree.GetComponent<Rigidbody>().AddForce(transform.position.x + 4f, transform.position.y + 4f, transform.position.z + 4f);
                    destructionScript.DestructionInitiator();
                }
            }
        }
    }
    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Tree"))
        {
            canCut = true;
        }
    }
}
