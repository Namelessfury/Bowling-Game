/*  File Name:          Save System.cs
 *  Purpose:            Save and Load System for the game.
 *  Contributors:       Myles Caesar
 *  Last Modified:      4/20/22 - Myles Caesar
 */

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    //saves the player's data
    public static void SavePlayer(int points, int[] inventory)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.file";  //where the player's data is saved
        FileStream stream = new FileStream(path, FileMode.Create);  //creates the file
        PlayerData data = new PlayerData(points, inventory);  //puts the data in a object to be saved

        formatter.Serialize(stream, data);  //saves the data to a file
        stream.Close();
    }

    //loads the player's data
    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.file";  //where the player's data is saved
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);    //opens the save data file

            PlayerData data = formatter.Deserialize(stream) as PlayerData;  //puts the save data into an object
            stream.Close();

            return data;    //returns the save data
        }
        else
        {
            int[] freshInventory = { 2, 0, 0, 0 };  //equips the default ball, all others balls are set to locked
            SavePlayer(0, freshInventory);    //if there is no save data, create fresh save data
            return LoadPlayer();    //return the fresh save data
        }
    }
}
