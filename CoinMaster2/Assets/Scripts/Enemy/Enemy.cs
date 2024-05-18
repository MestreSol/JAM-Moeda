using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Default")]
public class Enemy : ScriptableObject
{
    public int health;
    public int damage;
    public float speed;
    public float attackRange;
    public float attackSpeed;
    public float attackCooldown;
    public float attackTimer;

   
}
