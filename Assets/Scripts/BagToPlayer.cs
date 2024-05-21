using UnityEngine;

public class BagToPlayer : MonoBehaviour
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


    public void StartMoving()
    {
        move = true;
        startTime = Time.time;
    }

    void Update()
    {

        GetCenter();
        if (move == true)
        {
            float fracComplete = (Time.time - startTime) / travelTime * speed;
            bag.position = Vector3.Slerp(startCenter, endCenter, fracComplete * speed);
            bag.position += center;
        }
        if (Vector3.Distance(bag.position, player.position) < 2)
        {
            move = false;
        }
    }

    void GetCenter()
    {
        center = (bag.position + player.position) * 0.5f;
        center -= new Vector3 (0, 3, 0);
        startCenter = bag.position - center;
        endCenter = player.position - center;
    }
}
