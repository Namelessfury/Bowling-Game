/*  File Name:          Control Scripts.cs        
 *  Purpose:            Manages the movement of the bowling ball and its buttons.  
 *  Contributors:       Myles Ceasar
 *  Last Modified:      4/21/22 - Myles Caesar
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScripts : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private float move = 0.75f; //how far we move left and right when we press the button
    [SerializeField] private float leftbound = -5f; //ball can't go past leftbound
    [SerializeField] private float rightbound = 4f; //ball can't go past rightbound
    [SerializeField] private float force = 5000f; //how much force do we shoot with
    [SerializeField] private float turn = 1.5f; //how much do we turn when we press the button
  

    public event EventHandler OnButtonsDeactivated;

    private void Start()
    {
        //GameManager tells us when to reactivate the buttons
        GameManager manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        manager.OnBallReset += ReactivateButtons;
    }

    public void MoveLeft()
    {
        //Move the ball left
        Vector3 newposition = ball.transform.position + Vector3.left * move;

        //Ball can't go past leftbound
        if (newposition.x >= leftbound)
            ball.transform.position = newposition;
    }

    public void MoveRight()
    {
        //Move the ball right
        Vector3 newposition = ball.transform.position + Vector3.right * move;

        //Ball can't go past rightbound
        if (newposition.x <= rightbound)
            ball.transform.position = newposition;
    }
    public void TurnCounterClockwise()
    {
        //Turn the ball counterclockwise
        ball.transform.Rotate(new Vector3(0f, -turn, 0f));
    }

    public void TurnClockwise()
    {
        //Turn the ball clockwise
        ball.transform.Rotate(new Vector3(0f, turn, 0f));
    }

    public void Shoot()
    {
        //Shoot the ball forward
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0f,0f,force);
        
    }

    public void DeactivateButtons()
    {
        //Deactivate the control buttons
        foreach (GameObject button in buttons)
            button.SetActive(false);

        OnButtonsDeactivated?.Invoke(this, EventArgs.Empty);
    }

    public void ReactivateButtons(object sender, EventArgs e)
    {
        //Reactivate the control buttons
        foreach (GameObject button in buttons)
            button.SetActive(true);
    }


}
