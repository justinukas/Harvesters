using UnityEngine;

public class WheatDestruction : MonoBehaviour
{
    public void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            Invoke("Destruction", 1.5f);
        }
    }
    private void Destruction()
    {
        Destroy(gameObject);
    }
}