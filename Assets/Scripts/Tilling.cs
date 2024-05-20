using UnityEngine;

public class Tilling : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Tilling>().enabled = false;
    }

    public GameObject tilledDirt;
    public ParticleSystem ParticleSystem;

    private int TimesTilled = 0;

    void OnCollisionEnter(Collision collidedObject)
    {
        if (collidedObject.gameObject.CompareTag("Dirt") && gameObject.GetComponent<Tilling>().enabled == true /*(enables when its grabbed)*/)
        {
            Transform grassTransform = collidedObject.gameObject.transform;

            TimesTilled += 1;

            ParticleSystem dirtParticles = Instantiate(ParticleSystem, new Vector3(grassTransform.position.x, grassTransform.position.y + 0.67f, grassTransform.transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
            dirtParticles.Emit(8);
            dirtParticles.Stop();

            if (TimesTilled == 3)
            {
                dirtParticles.Emit(8);
                dirtParticles.Stop();
                Instantiate(tilledDirt, collidedObject.gameObject.transform.position, collidedObject.gameObject.transform.rotation);
                Destroy(collidedObject.gameObject);
                TimesTilled = 0;
            }
        }
    }
}
