using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GazeSelector : MonoBehaviour
{
    public float gazeDuration = 2f; // time required to select ui element
    private float gazeTimer = 0f;
    private bool isGazing = false;

    public Image LTD; // visual feedback for selection (this is what you want, this is what you get)

    private void Update()
    {
        if (isGazing)
        {
            gazeTimer += Time.deltaTime;
            LTD.fillAmount = gazeTimer / gazeDuration;

            if (gazeTimer >= gazeDuration)
            {
                OnSelected();
            }
        }
    }

    public void OnGazeEnter()
    {
        isGazing = true;
        LTD.gameObject.SetActive(true);
    }

    public void OnGazeExit()
    {
        isGazing = false;
        gazeTimer = 0f;
        LTD.fillAmount = 0f;
        LTD.gameObject.SetActive(false);
    }

    private void OnSelected()
    {
        // handles selectrion
        GetComponent<Button>().onClick.Invoke();
        ResetGaze();
    }

    private void ResetGaze()
    {
        isGazing = false;
        gazeTimer = 0f;
        LTD.fillAmount = 0f;
        LTD.gameObject.SetActive(false);
    }
}
