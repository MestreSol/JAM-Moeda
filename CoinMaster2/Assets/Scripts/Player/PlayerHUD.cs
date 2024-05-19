using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public static PlayerHUD instance;

    public TMP_Text interactText;
    public TMP_Text Life;
    public TMP_Text Ammo;
    public TMP_Text Coins;
    private void Awake()
    {
        instance = this;
    }
    public void Update()
    {
        if (Player.instance.health <= 0)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            Life.text = Player.instance.health.ToString();
            Ammo.text = Player.instance.currentAmmo + "/" + Player.instance.maxAmmo;
            Coins.text = Player.instance.coins.ToString();
        }
        
    }

    public void ShowInteractText(string text)
    {
        interactText.text = text;
        interactText.gameObject.SetActive(true);
    }

    public void HideInteractText()
    {
        interactText.gameObject.SetActive(false);
    }
}
