using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public static Inventory instance;
    public List<string> keysName = new List<string>();
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public bool Contains(Item item)
    {
        return items.Contains(item);
    }

    public void Use(Item item)
    {
        item.Use();
    }

    public void Use(Item item, GameObject obj)
    {
        item.Use();
    }

    public void AddKey(string keyName)
    {
        keysName.Add(keyName);
    }

    public void RemoveKey(string keyName)
    {
        keysName.Remove(keyName);
    }

    public bool ContainsKey(string keyName)
    {
        return keysName.Contains(keyName);
    }
}
