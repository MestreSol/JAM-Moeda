using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    public Vector3 scenePosition; // Adicionando uma variável para armazenar a posição da cena

    private bool playerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            GameObject loadedScene = SceneManager.GetSceneByName(sceneName).GetRootGameObjects()[0];
            Grid grid = loadedScene.gameObject.GetComponentInChildren<Grid>();
            grid.gameObject.transform.position = scenePosition;
        }
    }
}

