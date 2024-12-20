using UnityEngine;

public class Foggy : MonoBehaviour
{
    [SerializeField] private GameObject fogCircle;
    [SerializeField] private GameObject directionalLight;
    [SerializeField] private Transform player;

    private bool playerCollided;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            directionalLight.SetActive(false);
            fogCircle.GetComponent<Animator>().SetBool("enteredFog", true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            directionalLight.SetActive(true);
            fogCircle.GetComponent<Animator>().SetBool("enteredFog", false);
        }
    }
}
