using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuy : MonoBehaviour
{
    public int housePrice = 100;
    public GameObject housePrefab;

    public bool isPlayerInArea = false;
    public void BuyHouse()
    {
        if (Player.instance.RemoveCoins(housePrice))
        {
            Instantiate(housePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isPlayerInArea && Input.GetKeyDown(KeyCode.E))
        {
            BuyHouse();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.instance.coins >= housePrice)
            {
                isPlayerInArea = true;
                PlayerHUD.instance.ShowInteractText("Press E to buy house");
            }
            else
            {
                isPlayerInArea = false;
                PlayerHUD.instance.ShowInteractText("Not enough coins to buy house");
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInArea = false;
            PlayerHUD.instance.HideInteractText();
        }
    }
}
