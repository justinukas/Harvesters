using UnityEngine;

public class TpBack : MonoBehaviour
{
    void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.transform.parent != null)
        {
            collider.gameObject.transform.parent.position = new Vector3(114f, 3f, 38f);
        }

        if(collider.gameObject.transform.parent == null)
        {
            collider.gameObject.transform.position = new Vector3(114f, 3f, 38f);
        }
    }
}
