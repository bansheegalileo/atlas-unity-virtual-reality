using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // ref2 main menu panel
    public GameObject optionsPanel; // ref2 options panel

    // call this method when options button selected
    public void ShowOptionsMenu()
    {
        mainMenuPanel.SetActive(false); // hide main menu
        optionsPanel.SetActive(true);   // show options menu
    }

    // call this method when back button is selected
    public void ShowMainMenu()
    {
        optionsPanel.SetActive(false); // hide options menu
        mainMenuPanel.SetActive(true); // show main menu
    }
}
