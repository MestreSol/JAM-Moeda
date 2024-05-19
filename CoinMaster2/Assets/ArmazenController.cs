using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmazenController : MonoBehaviour
{
    public Button Bullet1;
    public Button Bullet2;
    public Button Bullet3;
    public Button Bullet4;

    public void SetTextBullet1()
    {
        Bullet1.GetComponentInChildren<TMP_Text>().text = "Normal\n Custo " + "1";
    }
    public void SetTextBullet2()
    {
        Bullet2.GetComponentInChildren<TMP_Text>().text = "Explosiva\n Custo " + "20";
    }
    public void SetTextBullet3()
    {
        Bullet3.GetComponentInChildren<TMP_Text>().text = "Veneno\n Custo " + "30";
    }
    public void SetTextBullet4()
    {
        Bullet4.GetComponentInChildren<TMP_Text>().text = "Fogo\n Custo " + "40";
    }

    public void BuyBullet1()
    {
        if (Player.instance.RemoveCoins(1))
        {
            Player.instance.AddAmmo(1);
        }
        else
        {
            Bullet1.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public void BuyBullet2()
    {
        if (Player.instance.RemoveCoins(20))
        {
            Player.instance.AddAmmo(2);
        }
        else
        {
            Bullet2.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public void BuyBullet3()
    {
        if (Player.instance.RemoveCoins(30))
        {
            Player.instance.AddAmmo(3);
        }
        else
        {
            Bullet3.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public void BuyBullet4()
    {
        if (Player.instance.RemoveCoins(40))
        {
            Player.instance.AddAmmo(4);
        }
        else
        {
            Bullet4.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public void SetText()
    {
        SetTextBullet1();
        SetTextBullet2();
        SetTextBullet3();
        SetTextBullet4();
        SetMaxAmmo();
        UpdateInvest();
    }

    public void Start()
    {
        SetText();
    }
    public Canvas canvas;
    public void Exit()
    {
        canvas.enabled = false;
        GameManager.Instance.gameState = GameState.Playing;
    }
    public TMP_Text bullets;
    public void Update()
    {
        if (Player.instance.currentAmmo == Player.instance.maxAmmo)
        {
            bullets.text = "Max Ammo";
        }
        else
        {
            bullets.text = "Ammo: " + Player.instance.currentAmmo + "/" + Player.instance.maxAmmo;
        }
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvas.enabled = true;
                GameManager.Instance.gameState = GameState.Paused;
            }
        }
    }

    public Button MaxAmmo;
    public int Level = 0;
    public void SetMaxAmmo()
    {
        MaxAmmo.GetComponentInChildren<TMP_Text>().text = "Max Ammo\n Custo " + (Player.instance.maxAmmo - (Level * 2));
    }

    public void BuyMaxAmmo()
    {
        if (Player.instance.RemoveCoins(Player.instance.maxAmmo - (Level * 2)))
        {
            Player.instance.maxAmmo++;
            SetMaxAmmo();
        }
        else
        {
            MaxAmmo.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public Button Investir;
    public void UpdateInvest()
    {
        Investir.GetComponentInChildren<TMP_Text>().text = "Investir\n Custo " + (Level * 5);
    }

    public void Invest()
    {
        if (Player.instance.RemoveCoins(Level * 5))
        {
            Level++;
            UpdateInvest();
        }
        else
        {
            Investir.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public bool isPlayerNear = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
            PlayerHUD.instance.ShowInteractText("Pressione E para entrar");
            SetText();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            PlayerHUD.instance.HideInteractText();
        }
    }

    
}

