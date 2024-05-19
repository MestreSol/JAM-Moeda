using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public bool isPlayerNear = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the exit!");
            PlayerHUD.instance.ShowInteractText("Press 'E' to exit the level");
            isPlayerNear = true;
        }

    }

    public void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player exited the level!");
            SceneManager.LoadScene("Initial");
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
