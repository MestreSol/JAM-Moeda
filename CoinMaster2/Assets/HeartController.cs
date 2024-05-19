using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public float grabRange = 5.0f;
    public float speed = 2.0f;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        grabRange = Player.instance.GrabRange();

    }

    void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= grabRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    public string fmodEventPath = "event:/HeartGrab";
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.instance.AddMoreLife(1);
            RuntimeManager.PlayOneShot(fmodEventPath, transform.position);
            Destroy(gameObject);
        }
    }
}
