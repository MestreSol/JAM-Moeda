using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureHUDController : MonoBehaviour
{
    public GameObject gameConfigScreen;
    public GameObject audioConfigScreen;
    public GameObject videoConfigScreen;
    public GameObject controlsConfigScreen;

    public MainMenuController mainMenuController;
    public GameObject thisScreen;
    

    private void DisableAll()
    {
        gameConfigScreen.SetActive(false);
        audioConfigScreen.SetActive(false);
        videoConfigScreen.SetActive(false);
        controlsConfigScreen.SetActive(false);
        thisScreen.SetActive(false);
    }

    public void ShowGameConfigScreen()
    {
        DisableAll();
        gameConfigScreen.SetActive(true);
    }
    public void ShowAudioConfigScreen()
    {
        DisableAll();
        audioConfigScreen.SetActive(true);
    }
    public void ShowVideoConfigScreen()
    {
        DisableAll();
        videoConfigScreen.SetActive(true);
    }
    public void ShowControlsConfigScreen()
    {
        DisableAll();
        controlsConfigScreen.SetActive(true);
    }
    public void ShowMainMenu()
    {
        DisableAll();
        mainMenuController.OpenMainScreen();
    }
    public void ShowThisScreen()
    {
        DisableAll();
        thisScreen.SetActive(true);
    }

}
