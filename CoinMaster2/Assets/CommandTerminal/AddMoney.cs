using CommandTerminal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
[RegisterCommand("add_money",Help = "")]
    public static void Add(CommandArg[] args)
    {
        int a = args[0].Int;

        if (Player.instance != null)
        {
            Player.instance.AddCoins(a);
        }
        else
        {
            Debug.LogError("Player instance not found");
        }
    }
   
}
