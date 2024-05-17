using UnityEngine;
using UnityEngine.Events;

public class ScriptTester : MonoBehaviour
{
    [SerializeField] UnityEvent Activation;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("tester collided");
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("invoked shit");
            Activation.Invoke();
        }
    }
}
