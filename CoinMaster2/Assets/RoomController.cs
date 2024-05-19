using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Door TopDoor;
    public Door BottomDoor;
    public Door LeftDoor;
    public Door RightDoor;

    public List<GameObject> Enemy;
    public void Awake()
    {
        var spawner = gameObject.GetComponentInChildren<SpawnerController>();
        spawner.EnemyQTD = Random.Range(1, 50);
        StartCoroutine(spawner.SpawnEnemy());

    }
    public void Update()
    {
        if (Enemy.Count == 0)
        {
            if (TopDoor != null)
            {
                TopDoor.isLocked = false;
                TopDoor.isClosed = false;
            }
            if (BottomDoor != null)
            {
                BottomDoor.isLocked = false;
                BottomDoor.isClosed = false;
            }
            if (LeftDoor != null)
            {
                LeftDoor.isLocked = false;
                LeftDoor.isClosed = false;
            }
            if (RightDoor != null)
            {
                RightDoor.isLocked = false;
                RightDoor.isClosed = false;
            }
        }
    }
}
