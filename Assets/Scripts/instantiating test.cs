using UnityEngine;
using UnityEngine.Events;

public class instantiatingtest : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    public Rigidbody cum;
    public Transform my_testicle;

    void OnTriggerEnter(Collider othercube)
    {
        if (othercube.CompareTag("Hoe"))
        {
            Debug.Log("i love minors");
            Invoke("MessageDelay", 3);
        }
    }
    void MessageDelay()
    {
        Debug.Log("wait i dont love minors");
        Instantiate(cum, my_testicle.position, my_testicle.rotation);
        return;
    }
}