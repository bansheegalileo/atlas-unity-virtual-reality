using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Emojiswapper : MonoBehaviour
{
    public GameObject rController; // Right hand controller
    public GameObject lController; // Left hand controller
    public GameObject head; // Head position
    public Image uiImage; // UI image to swap
    public Sprite defImage; // Default image
    public Sprite xArmsPose; // X arms pose
    public Sprite facepalmPose; // Facepalm pose
    public Sprite wavePose; // Wave pose

    public float facepalmRadius = 0.3f; // Radius for detecting facepalm
    public float waveRadius = 0.5f; // Radius for wave detection
    private bool isFacePalmActive = false;
    private bool isWaveActive = false;



    // Update is called once per frame
    void Update()
    {
        // Skip if facepalm is active
        if (!isFacePalmActive)
        {
            Vector3 rControllerPosition = rController.transform.position;
            Vector3 lControllerPosition = lController.transform.position;
            Vector3 headPos = head.transform.position;

            // Check if either controller is close enough to the head (within the facepalm radius)
            if (Vector3.Distance(rControllerPosition, headPos) < facepalmRadius || Vector3.Distance(lControllerPosition, headPos) < facepalmRadius)
            {
                if (!isFacePalmActive) // Only activate if not already active
                {
                    StartCoroutine(ShowFacePalmImage());
                }
            }
            else if (!isWaveActive) 
            {
             if (Vector3.Distance(rControllerPosition, headPos) > waveRadius || Vector3.Distance(lControllerPosition, headPos) > waveRadius)
                {
                    StartCoroutine(ShowWaveImage());
                }
            } 
            else
            {
                // If controllers are not near the head, check for cross arms pose
                if (Mathf.Abs(rControllerPosition.y - lControllerPosition.y) < 0.1f)
                {
                    if (rControllerPosition.x < headPos.x && lControllerPosition.x > headPos.x)
                    {
                        uiImage.sprite = xArmsPose;
                    }
                    else
                    {
                        uiImage.sprite = defImage;
                    }
                }
                else
                {
                    uiImage.sprite = defImage;
                }
            }
        }
    }

    IEnumerator ShowFacePalmImage()
    {
        isFacePalmActive = true;
        uiImage.sprite = facepalmPose;
        yield return new WaitForSeconds(3);
        isFacePalmActive = false;
    }
        IEnumerator ShowWaveImage()
    {
        isWaveActive = true;
        uiImage.sprite = wavePose;
        yield return new WaitForSeconds(3);
        isWaveActive = false;
    }
}
