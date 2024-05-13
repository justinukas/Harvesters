using UnityEngine;

public class PutPlantIn : MonoBehaviour
{
    public MeshFilter closedBagMesh;
    private MeshFilter openBagMesh;
    openBagMesh = gameObject.parent.GetComponentInChildren<MeshFilter>();
    int Weight;
    void OnCollisionEnter(Collision collider)
    {
        if (Weight >= 20)
        {
            openBagMesh = closedBagMesh;
        }
        if (collider.gameObject.CompareTag("Carrot"))
        {
        }
    }
    void BagClose()
    {
        if (Weight >=)
        {

        }
    }
}
