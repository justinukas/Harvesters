using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public void PlaySFX()
    {
        GetComponent<AudioSource>().Play();
    }
}
