using UnityEngine;

public class TreeCutting : MonoBehaviour
{
    private float cooldown = 0.2f;
    private GameObject theTree;
    private bool canCut = true;

    // cooldown timer method
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint contactPoint in collider.contacts) // this foreach is for checking if the collider colliding is the one of the axe's head
        {
            if (collider.gameObject.CompareTag("Tree") && cooldown <= 0 && canCut == true && contactPoint.thisCollider.gameObject.name == "Head")
            {
                canCut = false;
                cooldown = 0.2f; // reset cooldown timer

                theTree = collider.gameObject;

                TimesCut counterScript = theTree.GetComponent<TimesCut>();
                TreeDestruction destructionScript = theTree.GetComponent<TreeDestruction>();

                gameObject.GetComponent<AudioSource>().Play();
                gameObject.transform.Find("Head").Find("Particles").GetComponent<ParticleSystem>().Emit(20);

                counterScript.timesCut += 1;
                if (counterScript.timesCut >= 3)
                {
                    theTree.tag = "CutTree";

                    theTree.GetComponent<Rigidbody>().isKinematic = false;
                    theTree.GetComponent<Rigidbody>().AddForce(transform.forward * 2);
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
