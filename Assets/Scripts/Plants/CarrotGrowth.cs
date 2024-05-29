using UnityEngine;
using UnityEngine.Events;

public class CarrotGrowth : MonoBehaviour
{
    [SerializeField] UnityEvent DisableGrabbing;
    [SerializeField] UnityEvent EnableGrabbing;

    public bool hasParent = true;
    float growthRate = 0.39375f;

    void Update()
    {
        if (gameObject.transform.position.y <= 0.27f)
        {
            DisableGrabbing.Invoke();
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime * growthRate) / 120, transform.position.z);

        }

        if (gameObject.transform.position.y >= 0.27f)
        {
            EnableGrabbing.Invoke();

            CarrotGrowth carrotGrowth = gameObject.GetComponent<CarrotGrowth>();
            carrotGrowth.enabled = false;
        }
    }
    void nullifyParent()
    {
        transform.SetParent(null, true);
    }
}
