using UnityEngine;

public class BagWaterInteraction : MonoBehaviour
{
    public bool move;

    public Transform player;
    public Transform bag;

    private float travelTime = 10f;
    private float speed = 1f;

    private float startTime;
    private Vector3 center;
    private Vector3 startCenter;
    private Vector3 endCenter;


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Open Bag" || collider.gameObject.tag == "Closed Bag")
        {
            move = true;
            startTime = Time.time;

            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
    }

    void Update()
    {
        GetCenter(Vector3.up);
        if (move == true)
        {
            float fracComplete = (Time.time - startTime) / travelTime * speed;
            bag.position = Vector3.Slerp(startCenter, endCenter, fracComplete * speed);
            bag.position += center;
        }
        if (Vector3.Distance(bag.position, player.position) < 1)
        {
            move = false;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void GetCenter(Vector3 direction)
    {
        center = (bag.position + player.position) * 0.5f;
        center -= direction;
        startCenter = bag.position - center;
        endCenter = player.position - center;
    }
}
