using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public RoomController controller;
    public List<Transform> Spawnpoints;
    public List<GameObject> PosiblesEnemies;
    public int EnemyQTD;
    public int spawnedEnemies;
    public void Start()
    {
        // Inicializa a lista de inimigos
        controller.Enemy = new List<GameObject>();
        EnemyQTD = Random.Range(1, 50);
        StartCoroutine(SpawnEnemy());
    }
    public void InitializeRoom()
    {
        controller.Enemy = new List<GameObject>();
        EnemyQTD = Random.Range(1, 50);
        StartCoroutine(SpawnEnemy());
    }
    public IEnumerator SpawnEnemy()
    {
        // Enquanto houver inimigos para spawnar
        while (spawnedEnemies < EnemyQTD)
        {
            // Sorteia um inimigo
            int randomEnemy = Random.Range(0, PosiblesEnemies.Count);
            // Sorteia um ponto de spawn
            int randomSpawn = Random.Range(0, Spawnpoints.Count);
            // Instancia o inimigo no ponto de spawn
            var enemy = Instantiate(PosiblesEnemies[randomEnemy], Spawnpoints[randomSpawn].position, Quaternion.identity);

            // Adiciona o inimigo na lista de inimigos
            controller.Enemy.Add(enemy);
            spawnedEnemies++;

            // Espera 2 segundos antes de spawnar o próximo inimigo
            yield return new WaitForSeconds(2f);
        }
    }

    public void Update()
    {
        // Spawna inimigos a cada x tempo
        if (spawnedEnemies < EnemyQTD)
        {
            StartCoroutine(SpawnEnemy());
        }
    }
}
