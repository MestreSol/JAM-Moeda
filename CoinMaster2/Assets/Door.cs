using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = false;
    public bool isClosed = true;
    public bool isPlayerInTrigger = false;
    public bool isJaAberto = false;
    public string keyName;
    public Animator animator;
    public GameObject corredor;
    public int openingDirection;
    public Collider2D collider;

    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isJaAberto)
        {
            isPlayerInTrigger = true;
            PlayerHUD.instance.ShowInteractText("Press E to interact");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            PlayerHUD.instance.HideInteractText();
        }
    }

    private void Update()
    {
        if(isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && !isLocked)
        {
            if (isLocked)
            {
                if (Player.instance.inventory.ContainsKey(keyName))
                {
                    isLocked = false;
                    OpenDoor();
                }
            }
            else
            {
                if (isClosed)
                {
                    OpenDoor();
                }
                
            }
        }
    }
    public Vector2 offset;
    public Vector2 minimapOffset;
    public Vector2 corredorOffset;
    public void PlotOpen()
    {
        Debug.Log("Destroy Port " + gameObject.name);
        Destroy(gameObject,0.1f);
    }
    private void OpenDoor()
    {
        collider.enabled = false;
        Debug.Log("Try open door");
        Vector3 roomOffset;
        GameObject ins;
        switch (openingDirection)
        {
            case 1:
               roomOffset = new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z);

                corredorOffset = new Vector3(gameObject.transform.position.x + corredorOffset.x, gameObject.transform.position.y + corredorOffset.y, gameObject.transform.position.z);

                minimapOffset = new Vector3(gameObject.transform.position.x + minimapOffset.x, gameObject.transform.position.y + minimapOffset.y, gameObject.transform.position.z);

                
                ins = Instantiate(corredor);
                ins.transform.position = corredorOffset;
                RoomTemplates.instance.AddRoom(1, roomOffset, minimapOffset);
                
                break;
            case 2:
                

                roomOffset = new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z);

                corredorOffset = new Vector3(gameObject.transform.position.x + corredorOffset.x, gameObject.transform.position.y + corredorOffset.y, gameObject.transform.position.z);

                minimapOffset = new Vector3(gameObject.transform.position.x + minimapOffset.x, gameObject.transform.position.y + minimapOffset.y, gameObject.transform.position.z);


                ins = Instantiate(corredor);
                ins.transform.position = corredorOffset;
                RoomTemplates.instance.AddRoom(2, roomOffset, minimapOffset);
                break;
            case 3:
                roomOffset = new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z);

                corredorOffset = new Vector3(gameObject.transform.position.x + corredorOffset.x, gameObject.transform.position.y + corredorOffset.y, gameObject.transform.position.z);

                minimapOffset = new Vector3(gameObject.transform.position.x + minimapOffset.x, gameObject.transform.position.y + minimapOffset.y, gameObject.transform.position.z);


                ins = Instantiate(corredor);
                ins.transform.position = corredorOffset;
                RoomTemplates.instance.AddRoom(3, roomOffset, minimapOffset);
                break;
            case 4:

                roomOffset = new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z);

                corredorOffset = new Vector3(gameObject.transform.position.x + corredorOffset.x, gameObject.transform.position.y + corredorOffset.y, gameObject.transform.position.z);

                minimapOffset = new Vector3(gameObject.transform.position.x + minimapOffset.x, gameObject.transform.position.y + minimapOffset.y, gameObject.transform.position.z);


                ins = Instantiate(corredor);
                ins.transform.position = corredorOffset;
                RoomTemplates.instance.AddRoom(4, roomOffset, minimapOffset);
                break;
        }
        isJaAberto = true;
        Destroy(gameObject);
        Debug.Log("Destroy Port " + gameObject.name);
    }

    
}

