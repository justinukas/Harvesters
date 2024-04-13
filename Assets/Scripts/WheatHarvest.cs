using UnityEngine;
using UnityEngine.Events;

public class WheatHarvest : MonoBehaviour
{
    [SerializeField] UnityEvent PopSFX;

    private int WheatCutNr = 0;

    public Transform wheatBundle;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("WheatSmall"))
        {
            collider.GetComponent<BoxCollider>().isTrigger = false;
            collider.GetComponent<Rigidbody>().isKinematic = false;

            WheatCutNr = WheatCutNr+1;

            PopSFX.Invoke();

            if (WheatCutNr == 5) 
            {
                Instantiate(wheatBundle, gameObject.transform.position, gameObject.transform.rotation);
            }
        }
    }
}