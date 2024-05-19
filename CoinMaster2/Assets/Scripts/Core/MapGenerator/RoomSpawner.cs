using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public static RoomSpawner instance;

    public int openingDirection;
    private int rand;
    public bool spawned = false;
    public float waitTime = 4f;

    void Start()
    {
        instance = this;
    }

    public void Spawn(int direction, Vector3 spawnPosition, Vector3 minimapPosition)
    {
        if (!spawned)
        {
            GameObject[] rooms = null;
            GameObject[] place = null;
            switch (direction)
            {
                case 1: // Need to spawn a room with a BOTTOM door.
                    rooms = RoomTemplates.instance.bottomRooms;
                    break;
                case 2: // Need to spawn a room with a TOP door.
                    rooms = RoomTemplates.instance.topRooms;
                    break;
                case 3: // Need to spawn a room with a LEFT door.
                    rooms = RoomTemplates.instance.leftRooms;
                    break;
                case 4: // Need to spawn a room with a RIGHT door.
                    rooms = RoomTemplates.instance.rightRooms;
                    break;
            }

            if (rooms != null)
            {
                rand = Random.Range(0, rooms.Length);
                var obj = Instantiate(rooms[rand], minimapPosition, rooms[rand].transform.rotation);
                var objName = obj.name.Split("(Clone)");
                switch (objName[0])
                {
                    // B, L, LB, LR, R, RB, T,TB.TL.TR
                    case "B":
                        place = RoomTemplates.instance.BRoomsPrefab;
                        break;
                    case "L":
                        place = RoomTemplates.instance.LRoomPrefab;
                        break;
                    case "LB":
                        place = RoomTemplates.instance.LBRoomPrefab;
                        break;
                    case "LR":
                        place = RoomTemplates.instance.LRRoomPrefab;
                        break;
                    case "R":
                        place = RoomTemplates.instance.RRoomPrefab;
                        break;
                    case "RB":
                        place = RoomTemplates.instance.RBRoomPrefab;
                        break;
                    case "T":
                        place = RoomTemplates.instance.TRoomPrefab;
                        break;
                    case "TB":
                        place = RoomTemplates.instance.TBRoomPrefab;
                        break;
                    case "TL":
                        place = RoomTemplates.instance.TLRoomPrefab;
                        break;
                    case "TR":
                        place = RoomTemplates.instance.TRRoomPrefab;
                        break;
                }
                // Get Random place to spawn the next room
             if (place != null)
                {
                    rand = Random.Range(0, place.Length);
                    var placePloted = Instantiate(place[rand], spawnPosition, place[rand].transform.rotation);
                    switch (direction)
                    {
                        case 1:
                            placePloted.GetComponent<RoomController>().BottomDoor.PlotOpen();
                            break;
                        case 2:
                            placePloted.GetComponent<RoomController>().TopDoor.PlotOpen();
                            break;
                        case 3:
                            placePloted.GetComponent<RoomController>().LeftDoor.PlotOpen();
                            break;
                        case 4:
                            placePloted.GetComponent<RoomController>().RightDoor.PlotOpen();
                            break;
                    }
                }
                spawned = true;
                try
                {
                    gameObject.GetComponentInChildren<SpawnerController>().InitializeRoom();
                }
                catch (System.Exception)
                {
                    Debug.Log("No SpawnerController in " + gameObject.name);
                }
                RoomTemplates.instance.rooms.Add(gameObject);
                Debug.Log("Add Room type " + objName[0] + " in " + gameObject.name);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
            {
                Instantiate(RoomTemplates.instance.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
