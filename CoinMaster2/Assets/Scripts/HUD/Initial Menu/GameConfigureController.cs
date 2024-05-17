using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameConfigureController : MonoBehaviour
{
    public TMP_Dropdown LanguageDropdown;
    public Button ShowAchievements;
    public Button HardMode;

    private void Start()
    {
        //Add Languages to Dropdown
        LanguageDropdown.ClearOptions();
        LanguageDropdown.AddOptions(new List<string> { "Portuguese", "Portuguese 2" });
        LanguageDropdown.value = (int)ConfigureManager.Instance.Language;
        ShowAchievements.GetComponent<Image>().color = ConfigureManager.Instance.IsShowAchievements ? Color.green : Color.red;
        HardMode.GetComponent<Image>().color = ConfigureManager.Instance.IsHardMode ? Color.green : Color.red;
    }

    public void ChangeLanguage(int value)
    {
        ConfigureManager.Instance.Language = (Languages)value;
        PlayerPrefs.SetInt("Language", value);
        ConfigureManager.Instance.SaveConfigurations();
    }

    public void ChangeShowAchievements()
    {
        ConfigureManager.Instance.IsShowAchievements = !ConfigureManager.Instance.IsShowAchievements;
        PlayerPrefs.SetInt("IsShowAchievements", ConfigureManager.Instance.IsShowAchievements ? 1 : 0);
        ShowAchievements.GetComponent<Image>().color = ConfigureManager.Instance.IsShowAchievements ? Color.green : Color.red;
        ConfigureManager.Instance.SaveConfigurations();
    }

    public void ChangeHardMode()
    {
        ConfigureManager.Instance.IsHardMode = !ConfigureManager.Instance.IsHardMode;
        PlayerPrefs.SetInt("IsHardMode", ConfigureManager.Instance.IsHardMode ? 1 : 0);
        HardMode.GetComponent<Image>().color = ConfigureManager.Instance.IsHardMode ? Color.green : Color.red;
        ConfigureManager.Instance.SaveConfigurations();
    }
}
