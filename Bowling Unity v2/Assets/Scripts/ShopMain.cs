using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMain : MonoBehaviour
{
    public void BuyLuckyBall() {

        PlayerData Data = SaveSystem.LoadPlayer();
        int CurrentPoints = Data.points;
        int[] localInventory = Data.inventory;

        if (CurrentPoints < 30)
            return;

        if (localInventory[1] == 0)
            localInventory[1] = 1;
        if (localInventory[1] == 1) {
            localInventory[1] = 2;
            if (localInventory[0] == 2)
                localInventory[0] = 1;
            if (localInventory[2] == 2)
                localInventory[2] = 1;
            if (localInventory[3] == 2)
                localInventory[3] = 1;
        }

        SaveSystem.SavePlayer(CurrentPoints - 30, localInventory);
    }

    public void BuySkyBall() {

        PlayerData Data = SaveSystem.LoadPlayer();
        int CurrentPoints = Data.points;
        int[] localInventory = Data.inventory;

        if (CurrentPoints < 50)
            return;

        if (localInventory[2] == 0)
            localInventory[2] = 1;
        if (localInventory[2] == 1)
        {
            localInventory[2] = 2;
            if (localInventory[0] == 2)
                localInventory[0] = 1;
            if (localInventory[1] == 2)
                localInventory[1] = 1;
            if (localInventory[3] == 2)
                localInventory[3] = 1;
        }

        SaveSystem.SavePlayer(CurrentPoints - 50, localInventory);
    }

    public void BuyCosmicBall() {

        PlayerData Data = SaveSystem.LoadPlayer();
        int CurrentPoints = Data.points;
        int[] localInventory = Data.inventory;

        if (CurrentPoints < 70)
            return;

        if (localInventory[3] == 0)
            localInventory[3] = 1;
        if (localInventory[3] == 1)
        {
            localInventory[3] = 2;
            if (localInventory[0] == 2)
                localInventory[0] = 1;
            if (localInventory[1] == 2)
                localInventory[1] = 1;
            if (localInventory[2] == 2)
                localInventory[2] = 1;
        }

        SaveSystem.SavePlayer(CurrentPoints - 70, localInventory);
    }

    public void BackToMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
