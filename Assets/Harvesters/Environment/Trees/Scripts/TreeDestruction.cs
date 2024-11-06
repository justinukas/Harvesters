using UnityEngine;

public class TreeDestruction : MonoBehaviour
{
    public void DestructionInitiator()
    {
        Invoke(nameof(Destruction), 3);
    }
    private void Destruction()
    {
        Destroy(gameObject);
    }
}
