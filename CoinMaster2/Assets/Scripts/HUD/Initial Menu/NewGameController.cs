using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TMP_InputField AgeInput;
    public TMP_Dropdown Background;
    public TMP_Text T_Str;
    public TMP_Text T_Dex;
    public TMP_Text T_Con;
    public TMP_Text T_Int;
    public TMP_Text T_Wis;
    public TMP_Text T_Cha;
    public int TotalPoints = 10;
    public TMP_Text pontos;

    Save newSave;
    public void Awake()
    {
        pontos.text = 10.ToString();
        newSave = new Save();
        newSave.player = new Player();
        newSave.player.attributs = new PlayerAttributs();

        NameInput.text = "";
        AgeInput.text = "";

        T_Str.text = "10";
        T_Dex.text = "10";
        T_Con.text = "10";
        T_Int.text = "10";
        T_Wis.text = "10";
        T_Cha.text = "10";
        Background.ClearOptions();
        Background.AddOptions(new List<string> { "Acolyte", "Criminal", "Folk Hero", "Noble", "Sage", "Soldier" });
    }
    public void UpdateName(string value)
    {
        if (value.Length > 0)
        {
            newSave.Name = value;
            newSave.player.attributs.Name = value;  
        }

    }
    public void UpdateAge(string value)
    {
        if (int.TryParse(value, out int age))
        {
            newSave.player.attributs.Age = age;
            if (age <= 18)
                AgeInput.text = "Idade Invalida";
        }
        else
        {
            newSave.player.attributs.Age = 0;
            AgeInput.text = "0";
        }
    }
    public void UpdateBackground(int value)
    {
        newSave.player.attributs.Background = Background.options[value].text;
    }

    public void AddStr()
    {
        int newValue = int.Parse(T_Str.text) + 1;
        if (newValue < 0 || (TotalPoints - 1) < 0) return;
        T_Str.text = (int.Parse(T_Str.text) + 1).ToString();
        TotalPoints--;
        pontos.text = TotalPoints.ToString();
    }
    public void RemoveStr()
    {
        int newValue = int.Parse(T_Str.text) - 1;
        if (newValue < 0 ) return;
        T_Str.text = (int.Parse(T_Str.text) - 1).ToString();
        TotalPoints++;
        pontos.text = TotalPoints.ToString();
    }

    public void AddDex()
    {
        int newValue = int.Parse(T_Dex.text) + 1;
        if (newValue < 0 || (TotalPoints - 1) < 0) return;
        T_Dex.text = (int.Parse(T_Dex.text) + 1).ToString();
        TotalPoints--;
        pontos.text = TotalPoints.ToString();
    }
    public void RemoveDex()
    {
        int newValue = int.Parse(T_Dex.text) - 1;
        if (newValue < 0 ) return;
        T_Dex.text = (int.Parse(T_Dex.text) - 1).ToString();
        TotalPoints++;
        pontos.text = TotalPoints.ToString();
    }
    public void AddCon()
    {
        int newValue = int.Parse(T_Con.text) + 1;
        if (newValue < 0 || (TotalPoints - 1) < 0) return;
        T_Con.text = (int.Parse(T_Con.text) + 1).ToString();
        TotalPoints--;
        pontos.text = TotalPoints.ToString();
    }
    public void RemoveCon()
    {
        int newValue = int.Parse(T_Con.text) - 1;
        if (newValue < 0 ) return;
        T_Con.text = (int.Parse(T_Con.text) - 1).ToString();
        TotalPoints++;
        pontos.text = TotalPoints.ToString();
    }
    public void AddInt()
    {
        int newValue = int.Parse(T_Int.text) + 1;
        if (newValue < 0 || (TotalPoints - 1) < 0) return;
        T_Int.text = (int.Parse(T_Int.text) + 1).ToString();
        TotalPoints--;
        pontos.text = TotalPoints.ToString();
    }
    public void RemoveInt()
    {
        int newValue = int.Parse(T_Int.text) - 1;
        if (newValue < 0) return;
        T_Int.text = (int.Parse(T_Int.text) - 1).ToString();
        TotalPoints++;
        pontos.text = TotalPoints.ToString();
    }

    public void AddWis()
    {
        int newValue = int.Parse(T_Wis.text) + 1;
        if (newValue < 0 || (TotalPoints - 1) < 0) return;
        T_Wis.text = (int.Parse(T_Wis.text) + 1).ToString();
        TotalPoints--;
        pontos.text = TotalPoints.ToString();
    }
    public void RemoveWis()
    {
        int newValue = int.Parse(T_Wis.text) - 1;
        if (newValue < 0) return;

        T_Wis.text = (int.Parse(T_Wis.text) - 1).ToString();
        TotalPoints++;
        pontos.text = TotalPoints.ToString();
    }

    public void AddCha()
    {
        int newValue = int.Parse(T_Cha.text) + 1;
        if (newValue < 0 || (TotalPoints - 1) < 0) return;
        T_Cha.text = (int.Parse(T_Cha.text) + 1).ToString();
        TotalPoints--;
        pontos.text = TotalPoints.ToString();
    }
    public void RemoveCha()
    {
        int newValue = int.Parse(T_Cha.text) - 1;
        if (newValue < 0) return;
        T_Cha.text = (int.Parse(T_Cha.text) - 1).ToString();
        TotalPoints++;
        pontos.text = TotalPoints.ToString();
    }
    public PlayController playController;
    public void GenNewSave()
    {
        newSave.player.attributs.Strength = int.Parse(T_Str.text);
        newSave.player.attributs.Dexterity = int.Parse(T_Dex.text);
        newSave.player.attributs.Constitution = int.Parse(T_Con.text);
        newSave.player.attributs.Intelligence = int.Parse(T_Int.text);
        newSave.player.attributs.Wisdom = int.Parse(T_Wis.text);
        newSave.player.attributs.Charisma = int.Parse(T_Cha.text);
        newSave.player.attributs.Honor = 0;
        newSave.player.attributs.Sanidade = 100;
        newSave.CreatedAt = System.DateTime.Now.Date.ToString();
        newSave.LastPlayed = System.DateTime.Now.Date.ToString();
        newSave.LastSceneName = "Initial";
        newSave.Level = 1;
        newSave.Description = newSave.player.attributs.Background + " " + newSave.player.attributs.Name;
        newSave.Banner = null;
        newSave.Name = newSave.player.attributs.Name;

        if (GameManager.Instance != null && GameManager.Instance.SaveSystem != null)
        {
            Debug.Log("Try Save");
            GameManager.Instance.SaveSystem.NewSave(newSave);
        }
        else
        {
            Debug.LogError("GameManager.Instance ou GameManager.Instance.SaveSystem é null.");
        }

        // Pega a ultima scene do save e procura o numero dela
        int sceneNo = 0;
        if (newSave.LastSceneName != null)
        {
            sceneNo = GameManager.Instance.GetSceneNumber("Initial");
        }
        else
        {
            Debug.LogError("LastSceneName é null.");
        }
        GameManager.Instance.loadingScreenBarSystem.loadingScreen(1);
    }
}

