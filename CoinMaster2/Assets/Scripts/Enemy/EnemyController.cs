using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy Enemy;
    public bool isColliding;
    public Animator anim;
    public GameObject coinPrefab;
    public float QTDCoin;
    public GameObject heartPrefab;
    public string fmodEventPath;
    public void Start()
    {
        isColliding = false;
    }
    public void TakeDamage(int damage)
    {
        Enemy.health -= damage;
        anim.SetTrigger("Hit");
        RuntimeManager.PlayOneShot(fmodEventPath, transform.position);
        gameObject.GetComponent<EnemyUI>().UpdateLife(Enemy.health);
        if (Enemy.health <= 0)
        {
            // Drop Coin
            for (int i = 0; i < QTDCoin; i++)
            {
                var coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coin.GetComponent<CoinController>().InLive();
                coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * 100);
            }

            // Aleatoriamente dropa um coração
            if (Random.Range(0, 100) < 10)
            {
                var heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
                heart.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * 100);
            }
            Destroy(gameObject);

        }
    }
    public IEnumerator Attack()
    {
        while (isColliding)
        {
            ApplyDamage();
            yield return new WaitForSeconds(Enemy.attackCooldown);
        }
    }

    public void ApplyDamage()
    {
        if (isColliding)
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.TakeDamage(Enemy.damage);
            Debug.Log("Take Damage " + Enemy.damage);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            ApplyDamage();
            isColliding = true;
            StartCoroutine(Attack());
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
