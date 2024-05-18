using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Inventory/Bullet")]
public class Bullet : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject Prefab;
    public string Description;
    public float Damage;
    public float Speed;
}
