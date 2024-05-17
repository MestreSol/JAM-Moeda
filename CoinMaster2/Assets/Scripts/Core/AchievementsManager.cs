using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public string name;
    public string description;
    public bool unlocked;
    public int steamID;
}
public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager instance;
    public SteamController steamController;

    public List<Achievement> achievements;
}
