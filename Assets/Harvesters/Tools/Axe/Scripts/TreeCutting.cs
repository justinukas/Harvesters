using UnityEngine;

public class TreeCutting : MonoBehaviour
{
    private AudioSource soundEffect;
    private ParticleSystem woodParticles;

    private float cooldown = 0.2f;
    private bool leftTreeCollision = true;

    private void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        woodParticles = transform.Find("Head").Find("Particles").GetComponent<ParticleSystem>();
    }

    // cooldown timer method
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Tree"))
        {
            leftTreeCollision = true;
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint contactPoint in collider.contacts) // this foreach is for checking if the collider colliding is the one of the axe's head
        {
            if (collider.gameObject.CompareTag("Tree") && cooldown <= 0 && leftTreeCollision == true && contactPoint.thisCollider.gameObject.name == "Head")
            {
                GameObject tree = collider.gameObject;
                TimesCut counterScript = tree.GetComponent<TimesCut>();
                Destruction destructionScript = tree.GetComponent<Destruction>();

                leftTreeCollision = false;
                cooldown = 0.2f; // reset cooldown timer
                counterScript.timesCut += 1;
                if (counterScript.timesCut >= 3)
                {
                    FellTree(tree, destructionScript);
                }

                PlaySoundAndEmitParticles();
            }
        }
    }

    private void FellTree(GameObject tree, Destruction destructionScript)
    {
        tree.tag = "CutTree";

        // Make the tree fall in the direction of the front of the axe
        Rigidbody treeRigidBody = tree.GetComponent<Rigidbody>();
        treeRigidBody.isKinematic = false;
        treeRigidBody.AddForce(transform.forward * 2);

        // Destroy tree
        destructionScript.DestroyObject(2f);

        // Make apples fall down if its an apple tree that was cut down
        if (tree.name == "Apple Tree")
        {
            tree.GetComponent<AppleFall>().UnparentApples();
        }
    }

    private void PlaySoundAndEmitParticles()
    {
        soundEffect.Play();
        woodParticles.Emit(20);
    }
}
