using UnityEngine;

public class RenderingEnabler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collider)
    {
        if (!collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
        } //if not player tag DESTROY!! YOU CANT ESCAPE! BEGONE!
        
    }
}