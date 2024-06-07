using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestruction : MonoBehaviour
{
    public void DestructionInitiator()
    {
        Invoke("Destruction", 3);
    }
    private void Destruction()
    {
        Destroy(gameObject);
    }
}
