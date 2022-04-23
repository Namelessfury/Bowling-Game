/*  File Name:          GameManager.cs
 *  Purpose:            Manages the majority of the game mechanics, including score, turns,and pin and ball reset. 
 *  Contributors:       Ashley Mojica
 *                      Myles Caesar
 *  Last Modified:      4/22/2022 - Myles Caesar
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] pins;
    public float timeLimit = 8.0f;
    private float timer;

    public int score;
    public int turnsCounter;
    public int maxTurns;
    public Text pointsUI;
    public Text turnsUI;
    public Text roundEndPointsUI;
    AudioSource source;

    public Animator transition;
    public float transitionTime = 1f; 

    private Vector3[] pinPositions;
    private Quaternion pinRotation;
    private Vector3 ballPosition;
    private Quaternion ballRotation;

    [SerializeField] private GameObject ControlsUI;
    [SerializeField] private GameObject RoundEndUI;

    private bool endingFlag = false;

    public event EventHandler OnBallReset;

    // Start is called before the first frame update
    void Start()
    {
        //Get the pins positions 
        pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new Vector3[pins.Length];
        pinRotation = pins[0].transform.rotation;

        for (int i = 0; i < pins.Length; i++)
        {
            pinPositions[i] = pins[i].transform.position;
        }

        //Get the ball position
        ballPosition = ball.transform.position;
        ballRotation = ball.transform.rotation;

        //Set Timer
        timer = timeLimit;

        //Set Turns UI
        turnsUI.text = string.Concat(turnsCounter.ToString(), string.Concat("/", maxTurns));

    }

    // Update is called once per frame
    void Update()
    {
        
        //Start counting down timer after the ball has been launched
        if (ball.transform.position.z > -7)
        {
            timer -= Time.deltaTime;
        }

        //Once the ball lands in the ball pit
        if (ball.transform.position.y < -1 || timer < 0)
        {
            CountPinsDown();
            turnsCounter++;
            ResetBall();
            timer = timeLimit;           
        }

        //Once the user has three turns
        if (turnsCounter > 3 && endingFlag == false)
        {
            endingFlag = true;  //Makes sure the round end only happends once

            //Swaps the UI to the Round End UI
            roundEndPointsUI.text = pointsUI.text;
            ControlsUI.SetActive(false);
            RoundEndUI.SetActive(true);

            //Saves the player's points
            SavePoints();
        }
        else //If the user has not reached 3 turns, update turns UI
        {
            turnsUI.text = string.Concat(turnsCounter.ToString(), string.Concat("/", maxTurns));
        }

        
    }

    void CountPinsDown()
    {
        //Iterate through all pins on lane
        for (int i = 0; i < pins.Length; i++)
        {
            //If an active pin is knocked over
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
            else
            {
                //If the pin is not knocked over, ensure the pin is still and upright
                Rigidbody pinRB = pins[i].GetComponent<Rigidbody>();
                pinRB.velocity = Vector3.zero;
                pinRB.angularVelocity = Vector3.zero;
                pins[i].transform.position = pinPositions[i];
                pins[i].transform.rotation = pinRotation;
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
        OnBallReset?.Invoke(this, EventArgs.Empty); //Reactivates buttons and direction line
    }

    public void StartLoadLevelTransition()
    {
        //Deactivates RoundEndUI
        RoundEndUI.SetActive(false);

        //Starts the transition coroutine
        StartCoroutine(LoadLevelTransition());
    }

    IEnumerator LoadLevelTransition()
    {
        //Fades to black and loads Level Select scene
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level Select");
    }

    public void SavePoints()
    {
        //Earned points are added to the player's account
        PlayerData data = SaveSystem.LoadPlayer();
        SaveSystem.SavePlayer(data.points + int.Parse(pointsUI.text), data.inventory);
    }
}

    




