using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject playerPrefab;

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    public void Start()
    {
        if(Player.instance == null)
        {
            SpawnPlayer();
        }
        else
        {
            Player.instance.transform.position = transform.position;
        }
    }
}
