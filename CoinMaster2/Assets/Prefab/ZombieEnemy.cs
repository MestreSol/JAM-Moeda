using UnityEngine;

public class ZombieEnemy : Enemy
{
    public float speed = 3.0f;
    private Transform target;
    public EnemyUI enemyUI;
    public Rigidbody2D rb;
    void Start()
    {
        // Assume que o jogador tem a tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyUI.InitializeLife();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se o alvo existe (o jogador pode ter sido destruído)
        if (target != null)
        {
            // move rb
            Vector2 direction = target.position - transform.position;
            rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);

        }
    }

}