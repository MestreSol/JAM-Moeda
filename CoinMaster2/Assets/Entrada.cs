using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrada : MonoBehaviour
{
    public string sceneToLoad;
    private bool playerNearEntrance = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearEntrance = true;
            // Mostra a mensagem de interação
            Debug.Log("Pressione E para entrar");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearEntrance = false;
        }
    }

    private void Update()
    {
        if (playerNearEntrance && Input.GetKeyDown(KeyCode.E))
        {
            // Carrega a nova cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
