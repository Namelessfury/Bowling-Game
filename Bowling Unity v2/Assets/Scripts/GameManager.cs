using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] pins;
    public GameObject[] books; //level 1 objects
    public GameObject[] cans; //level 2 objects

    public int level = 0; 
    public int score = 0;
    public int turnsCounter = 1; 
    public Text pointsUI;

    private Vector3[] pinPositions;
    private Quaternion pinRotation;
    private Vector3 ballPosition;
    private Quaternion ballRotation;

    public event EventHandler OnPinsReset;

    // Start is called before the first frame update
    void Start()
    {
        //Get the pins positions 
        pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new Vector3[pins.Length];
        pinRotation = pins[0].transform.rotation;
        ballPosition = ball.transform.position;
        ballRotation = ball.transform.rotation;

        for(int i = 0; i < pins.Length; i++)
        {
            pinPositions[i] = pins[i].transform.position;
        }

        //Get Level Selected
        SelectLevel(level);
    }

    // Update is called once per frame
    void Update()
    {


        //Once the user has two turns
        if (turnsCounter == 2)
        {
            ResetPins();
            ResetCans();
        }

        //Once the ball lands in the ball pit
        if (ball.transform.position.y < -1)
        {
            CountPinsDown(); 
            turnsCounter++;
            ResetBall();
        }

        
    }

    void CountPinsDown()
    {
        //Iterate through all pins on lane
        for(int i = 0; i < pins.Length; i++)
        {
            //If an active pin is knocked over
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++; //Increase score
                pins[i].SetActive(false); //Set pin as inactive
            }
        }
        pointsUI.text = score.ToString(); //Update scoreboard
    }

    void ResetPins()
    {
        //Iterate through pins and reset them to their original position. 
        for (int i = 0; i < pins.Length; i++)
        {
            Rigidbody pinRB = pins[i].GetComponent<Rigidbody>();
            pins[i].SetActive(true);
            pinRB.velocity = Vector3.zero;
            pinRB.angularVelocity = Vector3.zero;
            pins[i].transform.position = pinPositions[i];
            pins[i].transform.rotation = pinRotation;
        }
    }
        

    void ResetBall()
    {
        //Puts the bowling ball back to its original position
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        ball.transform.position = ballPosition;
        ball.transform.rotation = ballRotation;
        OnPinsReset?.Invoke(this, EventArgs.Empty);
    }

    void SelectLevel(int level)
    {
        switch (level)
        {
            case 1:
                //books = GameObject.FindGameObjectsWithTag("Book");

                break;
            case 2:
                cans = GameObject.FindGameObjectsWithTag("Can");
                setCans();
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }

    void setCans()
    {
        setObjectsStanding(cans);

        cans[0].transform.position = new Vector3(2.36f, -0.299f, -65.43811f);
        cans[1].transform.position = new Vector3(1.09f, -0.299f, -58.18f);
        cans[2].transform.position = new Vector3(-1.99f, -0.299f, -61.1f);
        cans[3].transform.position = new Vector3(-3.44f, -0.299f, -67.89f);
        cans[4].transform.position = new Vector3(3.73f, -0.299f, -60.94f);

    }

    void ResetCans()
    {
        setObjectsStanding(cans);

        cans[0].transform.position = new Vector3(7.909999f, 30.07f, -63.6f);
        cans[1].transform.position = new Vector3(8.46f, 30.07f, -64.48f);
        cans[2].transform.position = new Vector3(7.931f, 30.07f, -65.59f);
        cans[3].transform.position = new Vector3(8.759998f, 30.07f, -66.24f);
        cans[4].transform.position = new Vector3(7.126f, 30.07f, -64.882f);
    }

    void setObjectsStanding(GameObject[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            Rigidbody RB = obj[i].GetComponent<Rigidbody>();
            obj[i].SetActive(true);
            RB.velocity = Vector3.zero;
            RB.angularVelocity = Vector3.zero;
            obj[i].transform.rotation = pinRotation;
        }
    }
}




