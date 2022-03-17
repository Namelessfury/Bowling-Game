using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScripts : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private float move = 1f;
    [SerializeField] private float leftbound = -4f;
    [SerializeField] private float rightbound = 3f;
    [SerializeField] private float force = 5000f;

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

    public void Shoot()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(0f,0f,force);
    }

    public void DeactivateButtons()
    {
        foreach (GameObject button in buttons)
            button.SetActive(false);
    }

}
