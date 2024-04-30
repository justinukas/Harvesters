using UnityEngine;

public class RenderingDisabler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collider)
    {
        if (!collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
        } //if not player tag DESTROY!! YOU CANT ESCAPE! BEGONE!
        
    }
}