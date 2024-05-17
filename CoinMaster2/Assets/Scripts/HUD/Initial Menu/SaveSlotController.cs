using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotController : MonoBehaviour
{
    public Image Sprite;
    public TMP_Text SaveName;
    public TMP_Text LastPlay;
    public TMP_Text CreatedAt;
    public TMP_Text SaveDescription;
    public TMP_Text SaveLevel;
    public Save SaveData;

    public void LoadSaveData(Save save)
    {
        SaveData = save;
        Sprite.sprite = save.Banner;
        SaveName.text = save.Name;
        LastPlay.text = "Last Played: " + save.LastPlayed;
        CreatedAt.text = "Created At: " + save.CreatedAt;
        SaveDescription.text = save.Description;
        SaveLevel.text = "Level " + save.Level;
    }

    public void Load()
    {
        GameManager.Instance.SaveSystem.LoadSave(SaveData);
    }

}
