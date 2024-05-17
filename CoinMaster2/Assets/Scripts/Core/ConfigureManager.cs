using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ConfigureManager : MonoBehaviour
{
    public Languages Language;
    public bool IsShowAchievements;
    public bool IsHardMode;
    public float MainVolume;
    public float MusicVolume;
    public float EffectsVolume;
    public float AmbienceVolume;
    public int Resolution;
    public int ScreenMode;
    public int ParticlesEffect;
    public int BluerQuality;
    public bool VSync;
    public static ConfigureManager Instance;

    private void Awake()
    {
        // Verifica se o arquivo de configuração ja existe caso não cria um
        Instance = this;
        if (PlayerPrefs.HasKey("Language"))
        {
            Language = (Languages)PlayerPrefs.GetInt("Language");
        }
        else
        {
            PlayerPrefs.SetInt("Language", (int)Languages.Portuguese);
            Language = Languages.Portuguese;
        }

        if (PlayerPrefs.HasKey("IsShowAchievements"))
        {
            IsShowAchievements = PlayerPrefs.GetInt("IsShowAchievements") == 1;
        }
        else
        {
            PlayerPrefs.SetInt("IsShowAchievements", 1);
            IsShowAchievements = true;
        }

        if (PlayerPrefs.HasKey("IsHardMode"))
        {
            IsHardMode = PlayerPrefs.GetInt("IsHardMode") == 1;
        }
        else
        {
            PlayerPrefs.SetInt("IsHardMode", 0);
            IsHardMode = false;
        }

        if (PlayerPrefs.HasKey("MainVolume"))
        {
            MainVolume = PlayerPrefs.GetFloat("MainVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("MainVolume", 1);
            MainVolume = 1;
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            MusicVolume = 1;
        }

        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            EffectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("EffectsVolume", 1);
            EffectsVolume = 1;
        }

        if (PlayerPrefs.HasKey("AmbienceVolume"))
        {
            AmbienceVolume = PlayerPrefs.GetFloat("AmbienceVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("AmbienceVolume", 1);
            AmbienceVolume = 1;
        }

        if (PlayerPrefs.HasKey("Resolution"))
        {
            Resolution = PlayerPrefs.GetInt("Resolution");
        }
        else
        {
            PlayerPrefs.SetInt("Resolution", 0);
            Resolution = 0;
        }

        if (PlayerPrefs.HasKey("ScreenMode"))
        {
            ScreenMode = PlayerPrefs.GetInt("ScreenMode");
        }
        else
        {
            PlayerPrefs.SetInt("ScreenMode", 0);
            ScreenMode = 0;
        }

        if (PlayerPrefs.HasKey("ParticlesEffect"))
        {
            ParticlesEffect = PlayerPrefs.GetInt("ParticlesEffect");
        }
        else
        {
            PlayerPrefs.SetInt("ParticlesEffect", 0);
            ParticlesEffect = 0;
        }

        if (PlayerPrefs.HasKey("BluerQuality"))
        {
            BluerQuality = PlayerPrefs.GetInt("BluerQuality");
        }
        else
        {
            PlayerPrefs.SetInt("BluerQuality", 0);
            BluerQuality = 0;
        }

        if (PlayerPrefs.HasKey("VSync"))
        {
            VSync = PlayerPrefs.GetInt("VSync") == 1;
        }
        else
        {
            PlayerPrefs.SetInt("VSync", 1);
            VSync = true;
        }


    }
    public void SaveConfigurations()
    {
        PlayerPrefs.SetInt("Language", (int)Language);
        PlayerPrefs.SetInt("IsShowAchievements", IsShowAchievements ? 1 : 0);
        PlayerPrefs.SetInt("IsHardMode", IsHardMode ? 1 : 0);
        PlayerPrefs.SetFloat("MainVolume", MainVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("EffectsVolume", EffectsVolume);
        PlayerPrefs.SetFloat("AmbienceVolume", AmbienceVolume);
        PlayerPrefs.SetInt("Resolution", Resolution);
        PlayerPrefs.SetInt("ScreenMode", ScreenMode);
        PlayerPrefs.SetInt("ParticlesEffect", ParticlesEffect);
        PlayerPrefs.SetInt("BluerQuality", BluerQuality);
        PlayerPrefs.SetInt("VSync", VSync ? 1 : 0);
    }
}
