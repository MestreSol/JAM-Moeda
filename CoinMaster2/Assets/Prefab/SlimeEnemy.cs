using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SlimeEnemey : Enemy
{
    public float speed = 3.0f;
    public float wanderRadius = 5.0f;
    private UnityEngine.Transform target;
    private Vector3 wanderTarget;
    public Rigidbody2D rb;
    void Start()
    {
        // Assume que o jogador tem a tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
        wanderTarget = RandomWanderTarget();
        speed = Random.RandomRange(1f, 5f);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se o alvo existe (o jogador pode ter sido destruído)
        if (target != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer < wanderRadius)
            {
                // Move o zumbi em direção ao jogador
                Vector2 direction = target.position - transform.position;
                rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);

            }
            else
            {
                // Move o zumbi em direção ao ponto de vagar
                Vector2 direction = wanderTarget - transform.position;
                rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);

                if (Vector3.Distance(transform.position, wanderTarget) < 0.2f)
                {
                    wanderTarget = RandomWanderTarget();
                }
            }
        }
    }

    Vector3 RandomWanderTarget()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        randomPoint.z = 0;
        return randomPoint;
    }
}
