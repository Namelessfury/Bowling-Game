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
    public int turnsCounter = 0; 
    public Text pointsUI;

    private Vector3[] positions;
    private Vector3 ballPosition;

    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];
        ballPosition = ball.transform.position;

        for(int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y < -1)
        {
            CountPinsDown();
            turnsCounter++;
            ResetPins();
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

    void ResetPins()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position = positions[i];
        }

        ball.transform.position = ballPosition;
    }
}
