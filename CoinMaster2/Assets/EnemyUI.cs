using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Slider Health;
    public Enemy enemy;
    public void UpdateLife(float life)
    {
        Health.value = life;
    }
    public void InitializeLife()
    {
        Health.maxValue = enemy.health;
        Health.value = enemy.health;
    }
}
