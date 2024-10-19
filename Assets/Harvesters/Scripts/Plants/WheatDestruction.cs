using UnityEngine;

public class WheatDestruction : MonoBehaviour
{
    public void InvokeWheatDestruction()
    {
        Invoke("Destruction", 1.5f);
    }
    private void Destruction()
    {
        Destroy(gameObject);
    }
}