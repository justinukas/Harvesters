using UnityEngine;

public class Harvestability : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CapsuleCollider>().enabled = false;
    }
    public void MakeHarvestable()
    {
        GetComponent<CapsuleCollider>().enabled = true;
    }

    public void Unparent()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
    }
}
