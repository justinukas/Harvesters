using UnityEngine;

public class BagToPlayer : MonoBehaviour
{
    public bool move;

    [SerializeField] private Transform player;
    [SerializeField] private Transform bag;

    private float travelTime = 10f;
    private float speed = 0.25f; // must be a value from 0f to 1f
    private float startTime;

    public void StartMoving()
    {
        move = true;
        startTime = Time.time;
    }

    private void Update()
    {
        if (move == true)
        {
            Vector3 center = (bag.position + player.position) / 2f;

            center -= new Vector3(0, 1, 0);

            Vector3 bagCenter = bag.position - center;

            Vector3 playerCenter = player.position - center;

            float fracComplete = (Time.time - startTime) / travelTime;

            bag.position = Vector3.Slerp(bagCenter, playerCenter, fracComplete * speed);

            bag.position += center;

        }
        if (Vector3.Distance(bag.position, player.position) < 1)
        {
            move = false;
        }
    }
}
