using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera MainCamera;
    void Update()
    {
        transform.forward = MainCamera.transform.forward;
    }
}
