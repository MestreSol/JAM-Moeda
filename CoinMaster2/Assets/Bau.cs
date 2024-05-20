using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
public class Bau : MonoBehaviour 
{
    public GameObject coinPrefab;
    public GameObject heartPrefab;
    public float heartDropChance = 0.1f;
    public bool isPlayerNearby = false;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            DropLoot();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            PlayerHUD.instance.ShowInteractText("Pressione E para abrir o bau");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            PlayerHUD.instance.HideInteractText();
        }
    }

    private void DropLoot()
    {
        // Dropa de 10 a 20 moedas
        int numCoins = Random.Range(10, 21);
        for (int i = 0; i < numCoins; i++)
        {
            GameObject coinInstance = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Rigidbody2D coinRb = coinInstance.GetComponent<Rigidbody2D>();
            if (coinRb != null)
            {
                coinRb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5f, ForceMode2D.Impulse);
            }
        }

        // Tem uma chance de dropar um coração
        if (Random.value < heartDropChance)
        {
            GameObject heartInstance = Instantiate(heartPrefab, transform.position, Quaternion.identity);
            Rigidbody2D heartRb = heartInstance.GetComponent<Rigidbody2D>();
            if (heartRb != null)
            {
                heartRb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5f, ForceMode2D.Impulse);
            }
        }
    }




}
