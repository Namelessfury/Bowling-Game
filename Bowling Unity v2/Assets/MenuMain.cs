using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{

    void Start() {
        //GameObject GameManagerObj = GameObject.Find("GameManager");
        //GameManager ManagerScript = GameManagerObj.GetComponent<GameManager>();
        GameObject pointsDisplay = GameObject.Find("pointTxt");
        GameManager ManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        int points = ManagerScript.score;
        string dis = points.ToString();
        updatePointCounter(dis, pointsDisplay);
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/Bowling Alley Scene.unity");
    }

    public void GoToShop() 
    {
        SceneManager.LoadScene("Assets/Scenes/GameShop.unity");
    }

    public void updatePointCounter(string Display, GameObject Counter) 
    {
        Counter.GetComponent<Text>().text = Display; 
    }
}
