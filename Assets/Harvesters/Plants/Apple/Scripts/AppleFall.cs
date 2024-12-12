using UnityEngine;

public class AppleFall : MonoBehaviour
{
    public void UnparentApples()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.name == "Apple")
            {
                child.parent = null;
                child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
