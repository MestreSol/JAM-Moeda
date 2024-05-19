using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public bool isPlayerNear = false;
    public Canvas Canvas;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the bar!");
            PlayerHUD.instance.ShowInteractText("Press 'E' to buy a drink");
            isPlayerNear = true;
            if (Player.instance.health == Player.instance.maxHealth)
            {
                MensagemTaverneiro.text = "Você já está bem volte mais tarde!";
            }
            else
            {
                MensagemTaverneiro.text = "Olá aventureiro, você quer uma bebida?";
            }
            DringCost.text = "Drink cost: " + Mathf.RoundToInt((5 * (Player.instance.maxHealth - Player.instance.health)));
            SetTextCha();
            SetTextCon();
            SetTextDex();
            SetTextInt();
            SetTextStr();
            SetTextWis();

        }

    }
    public int Level;
    public TMP_Text DringCost;
    public TMP_Text MensagemTaverneiro;
    public void BuyDrink()
    {
        if (Player.instance.RemoveCoins(Mathf.RoundToInt((5 * (Player.instance.maxHealth - Player.instance.health))) - Level * 2))
        {
            Player.instance.health = Player.instance.maxHealth;
            MensagemTaverneiro.text = "Valeu, mais tarde eu volto, disse o taverneiro!";
            DringCost.text = "";
        }
        else
        {
            DringCost.text = "Você não tem dinheiro suficiente!";
        }

    }
    public void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Canvas.enabled = true;
            GameManager.Instance.gameState = GameState.Paused;
        }
    }
    public Button Str;
    public void SetTextStr()
    {
        Str.GetComponentInChildren<TMP_Text>().text = "Strength: " + Player.instance.attributs.Strength + " + 1\nCOST: " + ((Player.instance.attributs.Strength * 2) - (Level * 2));
    }
    public void AddStr()
    {
        if (Player.instance.RemoveCoins(Mathf.RoundToInt((Player.instance.attributs.Strength * 2) - (Level * 2))))
        {
            Player.instance.attributs.Strength++;
            Level++;
            SetTextStr();
        }
        else
        {
            Str.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }
    public Button Dex;
    public void SetTextDex()
    {
        Dex.GetComponentInChildren<TMP_Text>().text = "Dexterity: " + Player.instance.attributs.Dexterity + " + 1\nCOST: " + ((Player.instance.attributs.Dexterity * 2) - (Level * 2));
    }
    public void AddDex()
    {
        if (Player.instance.RemoveCoins(Mathf.RoundToInt((Player.instance.attributs.Dexterity * 2) - (Level * 2))))
        {
            Player.instance.attributs.Dexterity++;
            Level++;
            SetTextDex();
        }
        else
        {
            Dex.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public Button Con;
    public void SetTextCon()
    {
        Con.GetComponentInChildren<TMP_Text>().text = "Constitution: " + Player.instance.attributs.Constitution + " + 1\nCOST: " + ((Player.instance.attributs.Constitution * 2) - (Level * 2));

    }

    public void AddCon()
    {
        if (Player.instance.RemoveCoins(Mathf.RoundToInt((Player.instance.attributs.Constitution * 2) - (Level * 2))))
        {
            Player.instance.attributs.Constitution++;
            Level++;
            SetTextCon();
        }
        else
        {
            Con.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }
    public Button Int;
    public void SetTextInt()
    {
        Int.GetComponentInChildren<TMP_Text>().text = "Intelligence: " + Player.instance.attributs.Intelligence + " + 1\nCOST: " + ((Player.instance.attributs.Intelligence * 2) - (Level * 2));
    }

    public void AddInt()
    {
        if (Player.instance.RemoveCoins(Mathf.RoundToInt((Player.instance.attributs.Intelligence * 2) - (Level * 2))))
        {
            Player.instance.attributs.Intelligence++;
            Level++;
            SetTextInt();
        }
        else
        {
            Int.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public Button Wis;
    public void SetTextWis()
    {
        Wis.GetComponentInChildren<TMP_Text>().text = "Wisdom: " + Player.instance.attributs.Wisdom + " + 1\nCOST: " + ((Player.instance.attributs.Wisdom * 2) - (Level * 2));
    }

    public void AddWis()
    {
        if (Player.instance.RemoveCoins(Mathf.RoundToInt((Player.instance.attributs.Wisdom * 2) - (Level * 2))))
        {
            Player.instance.attributs.Wisdom++;
            Level++;
            SetTextWis();
        }
        else
        {
            Wis.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }

    public Button Cha;
    public void SetTextCha()
    {
        Cha.GetComponentInChildren<TMP_Text>().text = "Charisma: " + Player.instance.attributs.Charisma + " + 1\nCOST: " + ((Player.instance.attributs.Charisma * 2) - (Level * 2));
    }

    public void AddCha()
    {
        if (Player.instance.RemoveCoins(Mathf.RoundToInt((Player.instance.attributs.Charisma * 2) - (Level * 2))))
        {
            Player.instance.attributs.Charisma++;
            Level++;
            SetTextCha();
        }
        else
        {
            Cha.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }
    public Button Invest;
    public void UpdateInvest()
    {
        Invest.GetComponentInChildren<TMP_Text>().text = "Investir: " + Level + " + 1\nCOST: " + (Level * 5);
    }

    public TMP_Text venenoCost;
    public void SetVenenoCost()
    {
        venenoCost.text = "Veneno cost: " + Mathf.RoundToInt(Player.instance.maxHealth * 5);
    }

    public void BuyMoreLife()
    {
        if(Player.instance.RemoveCoins(Mathf.RoundToInt(Player.instance.maxHealth * 5)))
        {
            Player.instance.maxHealth += 5;
            Player.instance.health = Player.instance.maxHealth;
            SetVenenoCost();
        }
        else
        {
            venenoCost.text = "Você não tem dinheiro suficiente!";
        }
    }
    public void Investir()
    {
        if(Player.instance.RemoveCoins(Level * 5))
        {
            Level++;
            UpdateInvest();
        }
        else
        {
            Invest.GetComponentInChildren<TMP_Text>().text = "Você não tem dinheiro suficiente!";
        }
    }
    public void Exit()
    {
        Canvas.enabled = false;
        GameManager.Instance.gameState = GameState.Playing;

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
