using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public static RoomTemplates instance;
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    //B, L, LB, LR, R, RB, T,TB.TL.TR
    public GameObject[] BRoomsPrefab;
    public GameObject[] LRoomPrefab;
    public GameObject[] LRRoomPrefab;
    public GameObject[] LBRoomPrefab;
    public GameObject[] RRoomPrefab;
    public GameObject[] RBRoomPrefab;
    public GameObject[] TRoomPrefab;
    public GameObject[] TBRoomPrefab;
    public GameObject[] TLRoomPrefab;
    public GameObject[] TRRoomPrefab;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    void Awake()
    {
        instance = this;
    }

    public void AddRoom(int direction, Vector3 position, Vector3 minimapPosition)
    {

        RoomSpawner.instance.Spawn(direction, position, minimapPosition);
        /*if (rooms.Count >= 5)
        {
            if (!spawnedBoss)
            {
                int randomIndex = Random.Range(0, rooms.Count);
                Instantiate(boss, rooms[randomIndex].transform.position, Quaternion.identity);
                spawnedBoss = true;
            }
        }*/
    }
}
