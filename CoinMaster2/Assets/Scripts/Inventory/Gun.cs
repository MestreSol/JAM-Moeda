using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Gun", menuName = "Inventory/Gun")]
public class Gun : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject Prefab;
    public string Description;
    public float Damage;
    public float FireRate;
    public float Range;
    public float Spread;
    public int MagazineSize;
    public int MaxAmmo;
    public float ReloadTime;
    public bool Automatic;
    public bool InfiniteAmmo;
    public Bullet bullet;
}
