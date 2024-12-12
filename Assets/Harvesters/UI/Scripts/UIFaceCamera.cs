using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
    }
    void Update()
    {
        transform.forward = MainCamera.transform.forward;
    }
}
