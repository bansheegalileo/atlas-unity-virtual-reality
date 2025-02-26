using UnityEngine;
using System.Collections;

public class MuteAudioOnStart : MonoBehaviour
{
    private void Start()
    {
        // coroutine to mute audio at start
        StartCoroutine(MuteAudioForSeconds(3f));
    }

    private IEnumerator MuteAudioForSeconds(float duration)
    {
        AudioListener.volume = 0f;

        yield return new WaitForSeconds(duration);

        AudioListener.volume = 1f;
    }
}