using UnityEngine;

public class Harvestability : MonoBehaviour
{
    public void MakeHarvestable()
    {
        GetComponent<MeshCollider>().enabled = true;
        transform.parent = null;
    }
}
