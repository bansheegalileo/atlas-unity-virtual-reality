using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkyboxManager : MonoBehaviour
{
    // Array to hold skybox materials
    public Material[] skyboxMaterials;

    // Index to track current skybox material
    private int currentSkyboxIndex = 0;

    // Reference to the fade effect UI element
    public UIFadeEffect fadeEffect;

    // Duration of the fade effect
    public float fadeDuration = 1.0f;

    void Start()
    {
        // set initial skybox material
        if (skyboxMaterials.Length > 0)
        {
            RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];
        }
    }

    void Update()
    {
        // listen for spacebar press to switch skyboxes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SwitchSkyboxWithFade());
        }
    }

    // method to switch to next skybox with fade effect
    private IEnumerator SwitchSkyboxWithFade()
    {
        yield return StartCoroutine(fadeEffect.FadeIn());

        currentSkyboxIndex++;

        if (currentSkyboxIndex >= skyboxMaterials.Length)
        {
            currentSkyboxIndex = 0;
        }

        // apply new skybox
        RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];

        DynamicGI.UpdateEnvironment();

        // fadein
        yield return StartCoroutine(fadeEffect.FadeOut());
    }

    // Call this method to switch to a specific skybox by index with fade effect
    public IEnumerator SetSkyboxWithFade(int index)
    {
        if (index >= 0 && index < skyboxMaterials.Length)
        {
            // fade from black
            yield return StartCoroutine(fadeEffect.FadeIn());

            currentSkyboxIndex = index;
            RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];

            DynamicGI.UpdateEnvironment();

            // fade to video
            yield return StartCoroutine(fadeEffect.FadeOut());
        }
    }
}
