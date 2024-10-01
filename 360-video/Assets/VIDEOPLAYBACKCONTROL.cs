using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerControls : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float playbackSpeed = 1.0f; // Default playback speed
    private bool isPaused = false;

    void Start()
    {    
        videoPlayer.Play();
        isPaused = false;
    }
    void Update()
    {
        // Variable playback speed
        if (Input.GetKeyDown(KeyCode.Equals)) // Press '=' to increase speed
        {
            playbackSpeed += 0.1f;
            videoPlayer.playbackSpeed = playbackSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Minus)) // Press '-' to decrease speed
        {
            playbackSpeed = Mathf.Max(0.1f, playbackSpeed - 0.1f);
            videoPlayer.playbackSpeed = playbackSpeed;
        }

        // Rewind
        if (Input.GetKeyDown(KeyCode.R)) // Press 'R' to rewind
        {
            videoPlayer.time -= 10; // Rewind by 10 seconds
        }

        // Fast-forward
        if (Input.GetKeyDown(KeyCode.F)) // Press 'F' to fast-forward
        {
            videoPlayer.time += 10; // Fast-forward by 10 seconds
        }

        // Looping
        if (Input.GetKeyDown(KeyCode.L)) // Press 'L' to toggle looping
        {
            videoPlayer.isLooping = !videoPlayer.isLooping;
        }

        // Skip to specific time
        if (Input.GetKeyDown(KeyCode.S)) // Press 'S' to skip to halfway point
        {
            videoPlayer.time = videoPlayer.length / 2;
        }

        // Pause/Resume
        if (Input.GetKeyDown(KeyCode.P)) // Press 'P' to pause/resume
        {
            if (isPaused)
            {
                videoPlayer.Play();
                isPaused = false;
            }
            else
            {
                videoPlayer.Pause();
                isPaused = true;
            }
        }
    }
}
