using UnityEngine;

public class WheatDestruction : MonoBehaviour
{
    public void DestructionInitiator()
    {
        Invoke("Destruction", 1.5f);
    }
    private void Destruction()
    {
        Destroy(gameObject);
    }
}