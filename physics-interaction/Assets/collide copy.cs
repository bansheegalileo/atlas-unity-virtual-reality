using UnityEngine;

public class PlaySoundOnCatllision : MonoBehaviour
{
    public AudioSource audioSource; // ref2 audio src
    public GameObject objectToActivate;
    private void OnCollisionEnter(Collision collision)
    {
        // check if src is assigned and not already playing
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // play
        }
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    private void Start()
    {
        // Ensure the object to activate is initially disabled
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }
}