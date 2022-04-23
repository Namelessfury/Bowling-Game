/*  File Name:         ShopMain.cs  
 *  Purpose:           Manages the shop logic. 
 *  Contributors:      Jose Valen
 *                     Myles Caesar
 *  Last Modified:     4/22/2022 - Myles Caesar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMain : MonoBehaviour
{
    //Buy the Retro Ball
    public void BuyRetroBall()
    {

        BuyBall(0, 0);
    }

    //Buy the Sky Ball
    public void BuySkyBall() {

        BuyBall(30, 1);
    }

    //Buy the Lucky Ball
    public void BuyLuckyBall() {

        BuyBall(50, 2);
    }

    //Buy the Cosmic Ball
    public void BuyCosmicBall() {

        BuyBall(70, 3);
    }

    //Buy a certain ball
    void BuyBall(int cost, int index)
    {
        PlayerData data = SaveSystem.LoadPlayer();
        int currentPoints = data.points;
        int[] localInventory = data.inventory;

        switch (localInventory[index]) 
        {
            case 2: //Already have the ball equipped
                return;
            case 1: //Already own the ball but it isn't equipped
                localInventory = EquipBall(index, localInventory);  //Equip ball
                SaveSystem.SavePlayer(currentPoints, localInventory);   //Save points and inventory
                break;
            case 0: //Don't own the ball
                if (currentPoints < cost)   //Not enough points to buy the ball
                    return;

                localInventory = EquipBall(index, localInventory);  //Equip ball
                SaveSystem.SavePlayer(currentPoints - cost, localInventory);    //Save remaining points and inventory
                break;
            default:
                break;
        }
    }

    //Equip a certain ball
    int[] EquipBall(int index, int[] localInventory)
    {
        for (int i = 0; i < localInventory.Length; i++)
        {
            if (localInventory[i] == 2) //the last ball that was equipped
                localInventory[i] = 1;

            if (i == index)             //the ball we are trying to equip
                localInventory[i] = 2;
        }

        return localInventory;
    }

    //Returns to the main menu
    public void BackToMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
