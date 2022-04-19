using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //makes the class able to be saved to a file
public class PlayerData
{
    public int points;
    public bool[] unlocks;

    public PlayerData(int newPoints, bool[] newUnlocks) //constructor for PlayerData
    {
        points = newPoints;
        unlocks = newUnlocks;
    }
}
