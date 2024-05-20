using FMODUnity;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float grabRange = 5.0f;
    public float speed = 2.0f;
    private Transform player;
    public int coinTier = 1;

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
    public void InLive()
    {
        coinTier = Random.Range(1, 4);
        switch (coinTier)
        {
            case 1:
                GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 0.75f);
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 0.5f);
                break;
            case 4:
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f);
                break;
        }
    }
    public string fmodEventPath = "event:/CoinGrab";
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.instance.AddCoins(4 * coinTier);
            RuntimeManager.PlayOneShot(fmodEventPath, transform.position);
            Destroy(gameObject);
        }
    }
}
