using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public UnityEngine.UI.Text CounterText;

    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        int PlayerPoints = data.points;
        updatePointCounter(PlayerPoints);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void GoToShop() 
    {
        SceneManager.LoadScene("GameShop");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void updatePointCounter(int Display) 
    {
        CounterText.GetComponent<Text>().text = Display.ToString(); 
    }
}
