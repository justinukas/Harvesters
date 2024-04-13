using UnityEngine;
using UnityEngine.Events;

public class WheatHarvest : MonoBehaviour
{
    int WheatCutNr;
    public Transform wheatBundle;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("WheatSmall"))
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            WheatCutNr += WheatCutNr;
        }
        if (WheatCutNr == 5)
        {
            Instantiate(wheatBundle, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}