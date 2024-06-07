using UnityEngine;

public class BagWaterInteraction : MonoBehaviour
{
    private BagToPlayer bagToPlayerScript;
    bool collided;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Open Bag" || collider.gameObject.tag == "Closed Bag")
        {
            bagToPlayerScript = collider.gameObject.GetComponent<BagToPlayer>();
            bagToPlayerScript.StartMoving();
            collided = true;
        }
    }

    private void Update()
    {
        if (collided)
        {
            if (bagToPlayerScript.move == true)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            if (bagToPlayerScript.move == false)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                collided = false;
            }
        }
    }
}
