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

    void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/Bowling Alley Scene.unity");
    }

    void GoToShop() 
    {
        SceneManager.LoadScene("Assets/Scenes/GameShop.unity");
    }

    void updatePointCounter(int Display) 
    {
        CounterText.GetComponent<Text>().text = Display.ToString(); 
    }
}
