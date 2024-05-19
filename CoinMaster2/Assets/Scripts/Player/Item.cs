using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Use()
    {
        Debug.Log("Using " + name);
    }
}
