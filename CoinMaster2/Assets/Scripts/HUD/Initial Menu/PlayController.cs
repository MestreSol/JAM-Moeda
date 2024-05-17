using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public GameObject SlotArea;
    public GameObject SaveSlotPrefab;
    public GameObject NewGame;
    public List<GameObject> slots;
    public void Start()
    {
        UpdateSaveList();
    }
    public void UpdateSaveList()
    {
        List<Save> saves = GameManager.Instance.SaveSystem.GetSaves();
        if (saves != null)
        {
            if (saves.Count > 0)
            {
                SlotArea.SetActive(true);
                foreach (Save save in saves)
                {
                    GameObject slot = Instantiate(SaveSlotPrefab, SlotArea.transform);
                    slot.GetComponent<SaveSlotController>().LoadSaveData(save);
                    slots.Add(slot);
                }
            }
            else
            {
                SlotArea.SetActive(false);
                NewGame.SetActive(true);
            }
        }
        else
        {
            SlotArea.SetActive(false);
            NewGame.SetActive(true);
        }
    }
    public void ShowNewGame()
    {
        NewGame.SetActive(true);
        SlotArea.SetActive(false);
        slots.Clear();
    }
    public void ShowSaves()
    {
        SlotArea.SetActive(true);
        NewGame.SetActive(false);
        UpdateSaveList();
        Debug.Log("Show Saves");
    }

    
}
