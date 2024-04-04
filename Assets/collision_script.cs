using UnityEngine;
public class DisappearOnTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            gameObject.SetActive(false);
        }
    }
}