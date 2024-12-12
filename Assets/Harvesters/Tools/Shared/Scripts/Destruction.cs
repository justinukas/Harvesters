using UnityEngine;

public class Destruction : MonoBehaviour
{
    public void DestroyObject(float delay)
    {
        Destroy(gameObject, delay);
    }
}
