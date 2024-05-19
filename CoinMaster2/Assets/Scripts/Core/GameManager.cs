using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SaveSystem SaveSystem;
    public Save CurrentSave;
    public LoadingScreenBarSystem loadingScreenBarSystem;
    public GameState gameState;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameState = GameState.Playing;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadScene(string sceneName)
    {

        loadingScreenBarSystem.loadingScreen(GetSceneNumber(name));
    }
    public int GetSceneNumber(string name)
    {
        // Pega a última cena do save.
       

        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("LastSceneName é null ou vazio.");
            return -1;
        }

        // Procura a cena pelo nome.
        Scene scene = SceneManager.GetSceneByName(name);

        // Retorna o número da cena.
        return scene.buildIndex;
    }
    public void GameOver()
    {
        // Carrega a cena de game over
        LoadScene("GameOver");
    }
}
