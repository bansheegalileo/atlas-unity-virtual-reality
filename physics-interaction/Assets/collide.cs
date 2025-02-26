using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource audioSource; // ref2 audio src

    private void OnCollisionEnter(Collision collision)
    {
        // check if src is assigned and not already playing
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // play
        }
    }
}