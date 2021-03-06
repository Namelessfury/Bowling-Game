/*  File Name:          PlayerData.cs
 *  Purpose:            A class file for our player's data (save class).
 *  Contributors:       Myles Caesar
 *  Last Modified:      4/20/22 - Myles Caesar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //makes the class able to be saved to a file
public class PlayerData
{
    public int points;  //number of points the player has
    public int[] inventory; //tells the status of each ball: 0 = locked, 1 = unlocked, 2 = equipped

    public PlayerData(int newPoints, int[] newInventory) //constructor for PlayerData
    {
        points = newPoints;
        inventory = newInventory;
    }
}
