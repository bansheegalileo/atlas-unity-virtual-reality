using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIFadeEffect : MonoBehaviour
{
    public Image fadeImage; // ui img comp
    public float fadeDuration = 1.0f; // fade duration

    private Color startColor;
    private Color endColor;

    void Start()
    {
        // init colors
        startColor = fadeImage.color;
        endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        fadeImage.color = endColor;
    }

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
    }
}
