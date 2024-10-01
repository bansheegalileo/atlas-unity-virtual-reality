using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class VRUIManager : MonoBehaviour
{
    // Array to hold skybox materials
    public Material[] skyboxMaterials;

    // Method to call when a button is clicked
    public void OnSkyboxButtonClicked(int index)
    {
        if (index >= 0 && index < skyboxMaterials.Length)
        {
            // Change the skybox material
            RenderSettings.skybox = skyboxMaterials[index];
            DynamicGI.UpdateEnvironment(); // Update lighting if needed

            // Output debug message to indicate successful skybox switch
            Debug.Log($"Skybox changed to: {skyboxMaterials[index].name}");
        }
        else
        {
            // Output debug message for invalid index
            Debug.LogWarning("Invalid skybox index: " + index);
        }
    }
}
