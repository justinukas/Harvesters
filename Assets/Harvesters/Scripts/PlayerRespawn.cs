using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= -20f)
        {
            transform.position = new Vector3(114f, 3f, 38f);
        }
    }
}
