using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] pins;
    public int score = 0;
    public Text pointsUI;

    // Start is called before the first frame update
    void Start()
    {

        pins = GameObject.FindGameObjectsWithTag("Pin");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y < -1)
        {
            CountPinsDown(); 
        }
    }

    void CountPinsDown()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }
        pointsUI.text = score.ToString();
    }
}
