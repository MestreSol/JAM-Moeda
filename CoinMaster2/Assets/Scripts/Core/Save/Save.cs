using System;   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public Sprite Banner;
    public string Name;
    public string Description;
    public int Level;
    public string LastPlayed;
    public string CreatedAt;
    public string LastSceneName;

    public Player player;
}
