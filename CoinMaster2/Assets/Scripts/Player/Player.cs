using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public Rigidbody2D rb;
    public PlayerAttributs attributs;
    public List<GunController> guns;
    public List<GunController> equippedGun;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attributs = GetComponent<PlayerAttributs>();
        guns = new List<GunController>();
        equippedGun = new List<GunController>();
        guns.Add(gameObject.GetComponentInChildren<GunController>());
        equippedGun.Add(guns[0]);
    }
    private void Update()
    {
        // Pega o input axis horizontal e vertical.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Cria um vetor de direção com base no input do jogador.
        Vector2 direction = new Vector2(horizontal, vertical);

        // Move o jogador na direção recebida.
        Move(direction);
        if(Input.GetMouseButtonDown(0))
        {
            equippedGun[0].Shoot();
        }
    }
    public void Move(Vector2 direction)
    {
        // Normaliza o vetor de direção para garantir que a velocidade do jogador seja constante em todas as direções.
        Vector2 normalizedDirection = direction.normalized;

        // Calcula a nova posição do jogador.
        Vector2 newPosition = rb.position + normalizedDirection * speed * Time.fixedDeltaTime;

        // Move o jogador para a nova posição.
        rb.MovePosition(newPosition);
    }
}
