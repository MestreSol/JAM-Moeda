using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoConfigureController : MonoBehaviour
{
    public TMP_Dropdown Resolution;
    public TMP_Dropdown ScreenMode;
    public TMP_Dropdown ParticlesEffect;
    public TMP_Dropdown BluerQuality;
    public Button VSync;

    public void Start()
    {
        // Get Possibles resolutions
        Resolution.ClearOptions();
        List<string> resolutions = new List<string>();
        foreach (Resolution res in Screen.resolutions)
        {
            resolutions.Add(res.width + "x" + res.height);
        }
        Resolution.AddOptions(resolutions);

        // Get Current Resolution
        Resolution.value = resolutions.IndexOf(Screen.width + "x" + Screen.height);

        // Set Screens Modes
        ScreenMode.ClearOptions();
        ScreenMode.AddOptions(new List<string> { "Windowed", "Fullscreen", "Borderless" });

        ScreenMode.value = (int)Screen.fullScreenMode;

        // Set Particles Effect
        ParticlesEffect.ClearOptions();
        ParticlesEffect.AddOptions(new List<string> { "Low", "Medium", "High" });

        // Set Bluer Quality
        BluerQuality.ClearOptions();
        BluerQuality.AddOptions(new List<string> { "Low", "Medium", "High" });
    }
    public void SetResolution()
    {
        string[] res = Resolution.options[Resolution.value].text.Split('x');
        Screen.SetResolution(int.Parse(res[0]), int.Parse(res[1]), Screen.fullScreenMode);
        ConfigureManager.Instance.Resolution = Resolution.value;
        ConfigureManager.Instance.SaveConfigurations();
    }
    public void SetScreenMode()
    {
        FullScreenMode mode;

        switch (ScreenMode.value)
        {
            case 0:
                mode = FullScreenMode.Windowed;
                break;
            case 1:
                mode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                mode = FullScreenMode.FullScreenWindow;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, mode);
                break;
            default:
                mode = FullScreenMode.Windowed;
                break;
        }

        Screen.fullScreenMode = mode;
        ConfigureManager.Instance.ScreenMode = ScreenMode.value;
        ConfigureManager.Instance.SaveConfigurations();
    }

    public void SetParticlesEffect()
    {
        // TODO
        ConfigureManager.Instance.ParticlesEffect = ParticlesEffect.value;
        ConfigureManager.Instance.SaveConfigurations();
    }
    public void SetBluerQuality()
    {
        // TODO
        ConfigureManager.Instance.BluerQuality = BluerQuality.value;
        ConfigureManager.Instance.SaveConfigurations();
    }
    public void ToggleVSync()
    {
        //Pega o botão e inverte o valor
        VSync.GetComponent<Image>().color = VSync.GetComponent<Image>().color == Color.green ? Color.red : Color.green;
        //Habilita o VSync
        QualitySettings.vSyncCount = ConfigureManager.Instance.VSync ? 1 : 0;

        ConfigureManager.Instance.VSync = !ConfigureManager.Instance.VSync;
        ConfigureManager.Instance.SaveConfigurations();

    }
}
