using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy Enemy;
    public bool isColliding;
    public void Start()
    {
        isColliding = false;
    }
    public void TakeDamage(int damage)
    {
       Enemy.health -= damage;
        if (Enemy.health <= 0)
        {
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
