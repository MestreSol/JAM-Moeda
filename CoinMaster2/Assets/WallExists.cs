using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExists : MonoBehaviour
{

    public bool wallExist = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallExist = true;
        }
        if(collision.gameObject.tag == "Player")
        {
            if (!wallExist)
            {
                Player.instance.TakeDamage(10000);
            }
        }
    }

}
