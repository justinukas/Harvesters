using UnityEngine;

public class Harvestability : MonoBehaviour
{
    private void Start()
    {
        GetComponent<MeshCollider>().enabled = false;
    }
    public void MakeHarvestable()
    {
        GetComponent<MeshCollider>().enabled = true;
    }

    public void Unparent()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
    }
}
