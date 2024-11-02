using UnityEngine;

public class Harvestability : MonoBehaviour
{
    public bool isHarvestable;

    public void MakeHarvestable()
    {
        GetComponent<MeshCollider>().enabled = true;
    }
}
