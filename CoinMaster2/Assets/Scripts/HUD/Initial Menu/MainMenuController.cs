using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject playScreen;
    public GameObject configurationsScreen;
    public GameObject mainScreen;
    private void Start()
    {
        OpenMainScreen();
    }
    public void OpenMainScreen()
    {
        DisableAll();
        mainScreen.SetActive(true);
    }
    public void OpenPlayScreen()
    {
        DisableAll();
        playScreen.SetActive(true);
    }
    public void OpenConfigurationsScreen()
    {
        DisableAll();
        configurationsScreen.SetActive(true);
    }
    public void DisableAll()
    {
        playScreen.SetActive(false);
        configurationsScreen.SetActive(false);
        mainScreen.SetActive(false);

    }
    public void Exit()
    {
        // Quit the game
        Application.Quit();
    }
}
