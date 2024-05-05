using UnityEngine;
using UnityEngine.Events;

public class Tilling : MonoBehaviour
{
    public Rigidbody tilledDirt;

    public ParticleSystem ParticleSystem;
    private ParticleSystem dirtParticles;

    private Transform grassTransform;
    
    private int TimesTilled = 0;

    void Start()
    {
        gameObject.GetComponent<Tilling>().enabled = false;
    }

    void OnCollisionEnter(Collision collidedObject)
    {
        if (collidedObject.gameObject.CompareTag("Dirt") && gameObject.GetComponent<Tilling>().enabled == true /* (enables when its grabbed) */)
        {
            grassTransform = collidedObject.gameObject.transform;

            TimesTilled = TimesTilled + 1;

            dirtParticles = Instantiate(ParticleSystem, new Vector3(grassTransform.position.x, grassTransform.position.y + 0.67f, grassTransform.transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
            dirtParticles.Emit(8);
            dirtParticles.Stop();

            if (TimesTilled == 3)
            {
                dirtParticles.Emit(8);
                Instantiate(tilledDirt, collidedObject.gameObject.transform.position, collidedObject.gameObject.transform.rotation);
                Destroy(collidedObject.gameObject);
                TimesTilled = 0;
            }
        }
    }
}