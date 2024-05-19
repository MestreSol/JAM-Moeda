using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMessage : MonoBehaviour
{
    public List<string> messages = new List<string>();
    public WitringText witringText;
    public float timeBetweenMessages = 5f;
    public void Start()
    {
        StartCoroutine(ShowRandomMessage());
    }
    IEnumerator ShowRandomMessage()
    {
        string lastMessage = null;
        while (true)
        {
            string nextMessage;
            do
            {
                nextMessage = messages[Random.Range(0, messages.Count)];
            } while (nextMessage == lastMessage);

            witringText.StartTyping(nextMessage);
            lastMessage = nextMessage;
            yield return new WaitForSeconds(timeBetweenMessages);
        }
    }


}
