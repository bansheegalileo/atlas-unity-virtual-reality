using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour
{
    public GameObject lightObject;
    public float minFlickerTime = 0.1f;
    public float maxFlickerTime = 1.0f;
    private void Start()
    {
        StartCoroutine(FlickerLight());
    }

    private IEnumerator FlickerLight()
    {
        while (true)
        {
            float waitTime = Random.Range(minFlickerTime, maxFlickerTime);
            yield return new WaitForSeconds(waitTime);

            lightObject.SetActive(!lightObject.activeSelf);
        }
    }
}
