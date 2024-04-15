using UnityEngine;

public class WheatDestruction : MonoBehaviour
{
    public void Update()
    {
        if (gameObject.GetComponent<BoxCollider>().isTrigger == false && gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            Invoke("Destruction", 2);
        }
    }
    private void Destruction()
    {
        Destroy(gameObject);
    }
}