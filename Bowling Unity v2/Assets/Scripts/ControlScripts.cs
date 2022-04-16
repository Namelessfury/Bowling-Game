using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScripts : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private float move = 0.75f;
    [SerializeField] private float leftbound = -5f;
    [SerializeField] private float rightbound = 4f;
    [SerializeField] private float force = 5000f;
    [SerializeField] private float turn = 1.5f;
  

    public event EventHandler OnButtonsDeactivated;

    private void Start()
    {
        GameManager manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        manager.OnPinsReset += ReactivateButtons;
    }

    public void MoveLeft()
    {
        Vector3 newposition = ball.transform.position + Vector3.left * move;

        if (newposition.x >= leftbound)
            ball.transform.position = newposition;
    }

    public void MoveRight()
    {
        Vector3 newposition = ball.transform.position + Vector3.right * move;

        if (newposition.x <= rightbound)
            ball.transform.position = newposition;
    }
    public void TurnCounterClockwise()
    {
        ball.transform.Rotate(new Vector3(0f, -turn, 0f));
    }

    public void TurnClockwise()
    {
        ball.transform.Rotate(new Vector3(0f, turn, 0f));
    }

    public void Shoot()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0f,0f,force);
    }

    public void DeactivateButtons()
    {
        foreach (GameObject button in buttons)
            button.SetActive(false);

        OnButtonsDeactivated?.Invoke(this, EventArgs.Empty);
    }

    public void ReactivateButtons(object sender, EventArgs e)
    {
        foreach (GameObject button in buttons)
            button.SetActive(true);
    }


}
