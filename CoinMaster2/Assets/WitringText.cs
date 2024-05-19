using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WitringText : MonoBehaviour
{
    public TMP_Text textComponent;
    public float typingSpeed = 0.02f;
    public bool StartOnAwake = false;
    public string text;
    public void Start()
    {
        if (StartOnAwake)
        {
            StartTyping(text);
        }
    }
    public void StartTyping(string text)
    {
        StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        textComponent.text = "";
        foreach (char letter in text.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
