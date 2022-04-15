using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RayFromGround : MonoBehaviour
{
    private GameObject obj;
    private LineRenderer line;
    [SerializeField] private float lineLength = 36;

    void Start()
    {
        obj = gameObject;
        line = gameObject.GetComponent<LineRenderer>();

        ControlScripts control = FindObjectOfType<ControlScripts>().GetComponent<ControlScripts>();
        control.OnButtonsDeactivated += DisableLine;

        GameManager manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        manager.OnPinsReset += ActivateLine;
    }

    void Update()
    {
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
        line.enabled = false;
    }

    private void ActivateLine(object sender, EventArgs e)
    {
        line.enabled = true;
    }
}
