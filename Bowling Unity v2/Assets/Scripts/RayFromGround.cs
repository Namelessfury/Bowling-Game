/*  File Name:              Ray From Ground
 *  Purpose:                Makes a direction line below the ball if there's ground below it
 *  Contributors:           Myles Caesar   
 *  Last Modified:          4/14/22 - Myles Caesar
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RayFromGround : MonoBehaviour
{
    private GameObject obj; //what is the line coming from
    private LineRenderer line;  //our pre-made line
    [SerializeField] private float lineLength = 36; //how long is the direction line

    void Start()
    {
        obj = gameObject;
        line = gameObject.GetComponent<LineRenderer>();

        //ControlScript tells use when to disable the direction line
        ControlScripts control = FindObjectOfType<ControlScripts>().GetComponent<ControlScripts>();
        control.OnButtonsDeactivated += DisableLine;

        //GameManager script tells use when to reactivate the direction line
        GameManager manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        manager.OnBallReset += ActivateLine;
    }

    void Update()
    {
        //Displays the direction line only if there is ground below the ball
        if (line.enabled)
        {
            RaycastHit hit;
            Ray downRay = new Ray(obj.transform.position, -Vector3.up);

            if (Physics.Raycast(downRay, out hit))
            {
                line.SetPosition(0, hit.point);
                line.SetPosition(1, hit.point + obj.transform.forward * lineLength);
            }
            else
            {
                line.SetPosition(0, obj.transform.position);
                line.SetPosition(1, obj.transform.position);
            }
        }
    }

    private void DisableLine(object sender, EventArgs e)
    {
        //Deactivates the direction line
        line.enabled = false;
    }

    private void ActivateLine(object sender, EventArgs e)
    {
        //Reactivates the direction line
        line.enabled = true;
    }
}
