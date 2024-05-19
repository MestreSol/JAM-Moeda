using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactoController : MonoBehaviour
{
    public int damage;
    public float attackCooldown;
    public bool isColliding;

    public void Start()
    {
        isColliding = false;
    }

    public void ApplyDamage()
    {
        if (isColliding)
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.TakeDamage(damage);
            Debug.Log("Take Damage " + damage);
        }
    }

    public IEnumerator Attack()
    {
        while (isColliding)
        {
            ApplyDamage();
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
