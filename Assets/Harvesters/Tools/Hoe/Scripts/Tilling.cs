using UnityEngine;

public class Tilling : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Tilling>().enabled = false;
    }

    private float cooldown = 0.25f;
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public GameObject tilledDirt;
    public ParticleSystem ParticleSystem;

    private void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint contactPoint in collider.contacts) // this foreach is for checking if the loclcollider colliding is the correct one
        {
            if (collider.gameObject.CompareTag("Dirt") && cooldown <= 0 && gameObject.GetComponent<Tilling>().enabled == true /* <- this enables when object is grabbed */ && contactPoint.thisCollider.gameObject.name == "Head")
            {
                TillCounter tillCounter = collider.gameObject.GetComponent<TillCounter>();
                tillCounter.timesTilled += 1;

                cooldown = 0.25f;

                Transform grassTransform = collider.gameObject.transform;

                ParticleSystem dirtParticles = Instantiate(ParticleSystem, new Vector3(grassTransform.position.x, grassTransform.position.y + 0.67f, grassTransform.transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
                dirtParticles.Emit(8);
                dirtParticles.Stop();

                
                if (tillCounter.timesTilled == 3)
                {
                    dirtParticles.Emit(8);
                    dirtParticles.Stop();
                    Instantiate(tilledDirt, collider.gameObject.transform.position, collider.gameObject.transform.rotation);
                    Destroy(collider.gameObject);
                }
            }
        }
    }
}
