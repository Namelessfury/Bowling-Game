using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMain : MonoBehaviour
{
    public void BuyLuckyBall() { }

    public void BuySkyBall() { }

    public void BuyCosmicBall() { }

    public void BackToMenu() 
    {
        SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
    }
}
