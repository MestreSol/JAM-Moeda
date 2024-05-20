using FMODUnity;
using Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{

    public static Player instance;

    public Rigidbody2D rb;
    public PlayerAttributs attributs;
    public List<GunController> guns;
    public List<GunController> equippedGun;
    public Inventory inventory;

    public int ZombiesDead;
    public int SlimesDead;
    public int SkeletonsDead;

    public int coins;
    public int maxAmmo = 100;
    public int currentAmmo = 100;

    public bool CanShoot()
    {
        return currentAmmo > 0;
    }
    public float GrabRange()
    {
        return attributs.Dexterity;
    }
    public string fmodEventPath_Hit = "event:/PlayerHit";
    public string fmodEventPath_Die = "event:/PlayerDie";
    
    public void TakeDamage(int damage)
    {
        RuntimeManager.PlayOneShot(fmodEventPath_Hit, transform.position);

        health -= damage;
        if (health <= 0)
        {
            if(SteamManager.Initialized)
            {
                SteamUserStats.SetAchievement("Prezunto_1");
                SteamUserStats.StoreStats();
            }
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        if(SteamManager.Initialized)
        {
            SteamUserStats.SetStat("Coins", coins);
            SteamUserStats.StoreStats();
        }
    }
    public bool RemoveCoins(int amount)
    {
        if(coins - amount >= 0)
        {
            coins -= amount;
            return true;
        }
        return false;
    }
    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
    public void RemoveAmmo(int amount)
    {
        currentAmmo -= amount;
        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }
    }
    public void AddMoreMaxAmmo(int amount)
    {
        maxAmmo += amount;
    }
    public void AddMoreLife(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public void AddMoreMaxLife(int amount)
    {
        maxHealth += amount;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attributs = GetComponent<PlayerAttributs>();
        guns = new List<GunController>();
        equippedGun = new List<GunController>();
        guns.Add(gameObject.GetComponentInChildren<GunController>());
        equippedGun.Add(guns[0]);
        instance = this;
        DontDestroyOnLoad(gameObject);
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
        if(Input.GetMouseButtonDown(0) && GameManager.Instance.gameState == GameState.Playing)
        {
            equippedGun[0].Shoot();
        }
    }
    public void Move(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    }


}
