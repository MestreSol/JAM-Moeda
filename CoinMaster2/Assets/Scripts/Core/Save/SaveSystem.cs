using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string savePath;

    public void Awake()
    {
        savePath = Path.GetTempPath();
    }
    public void SetFileName(string characterName)
    {
        string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoinMaster2\\Saves");
        // Cria o diretório se ele não existir.
        Directory.CreateDirectory(directoryPath);


        savePath = Path.Combine(directoryPath, characterName + "_save.json");
    }
    public void NewSave(Save save)
    {
        Debug.Log("New Save");
        SaveGame(save);
    }
    public void SaveGame(Save data)
    {
        // Serializa os dados para JSON.
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        SetFileName(data.Name);
        // Escreve o JSON para o arquivo.
        File.WriteAllText(savePath, json);
        Debug.Log("Saved to " + savePath);
    }
    public List<Save> GetSaves()
    {
        List<Save> saves = new List<Save>();
        string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoinMaster2\\Saves");

        // Obtém todos os arquivos JSON na pasta.
        try
        {
            string[] files = Directory.GetFiles(directoryPath, "*_save.json");

            Debug.Log("Load Files in: " + directoryPath);
        
        foreach (string file in files)
        {
            // Lê o JSON do arquivo.
            string json = File.ReadAllText(file);

            // Desserializa o JSON para os dados.
            Save data = JsonUtility.FromJson<Save>(json);

            // Adiciona os dados à lista de saves.
            saves.Add(data);
        }
        Debug.Log("Founded: "+saves.Count+" in "+directoryPath);
        return saves;
        }
        catch (Exception)
        {
            Debug.Log("No files found in: " + directoryPath);
            return null;
        }
        
    }
    public Save LoadSaves()
    {
        if (File.Exists(savePath))
        {
            // Lê o JSON do arquivo.
            string json = File.ReadAllText(savePath);

            // Desserializa o JSON para os dados.
            Save data = JsonUtility.FromJson<Save>(json);

            return data;
        }
        else
        {
            Debug.LogError("Save file not found at " + savePath);
            return null;
        }
    }
    public void LoadSave(Save data) { 
        if(data != null)
        {
            GameManager.Instance.CurrentSave = data;
            GameManager.Instance.LoadScene(data.LastSceneName);
        }
        else
        {
            Debug.LogError("Save file not found at " + savePath);
        }
    }
}
