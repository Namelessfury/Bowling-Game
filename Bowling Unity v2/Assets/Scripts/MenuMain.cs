/*  File Name:         MainMenu.cs  
 *  Purpose:           Functionality of the main menu buttons. 
 *  Contributors:      Jose Valen
 *                     Myles Caesar
 *  Last Modified:     4/22/2022 - Myles Caesar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public Text CounterText; //Points display on the main menu

    void Start()
    {
        //Gets player's saved data and updates points display
        PlayerData data = SaveSystem.LoadPlayer();
        int PlayerPoints = data.points;
        updatePointCounter(PlayerPoints);
    }

    public void PlayGame()
    {
        //Goes to level select
        SceneManager.LoadScene("Level Select");
    }

    public void GoToShop() 
    {
        //Goes to the game shop
        SceneManager.LoadScene("GameShop");
    }

    public void ExitGame()
    {
        //Quits the game
        Application.Quit();
    }

    void updatePointCounter(int Display) 
    {
        //Updates the points on the main menu
        CounterText.text = Display.ToString(); 
    }
}
