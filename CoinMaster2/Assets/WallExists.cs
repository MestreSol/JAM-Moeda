using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExists : MonoBehaviour
{

    public bool wallExist = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Debug.Log("Wall exists");
            wallExist = true;
        }
        if(other.gameObject.tag == "Player" && !wallExist)
        {
            Player.instance.TakeDamage(100000); 
        }
    }
}
