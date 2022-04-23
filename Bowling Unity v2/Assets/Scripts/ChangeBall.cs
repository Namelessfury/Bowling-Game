/*  File Name:          Changeball.cs        
 *  Purpose:            Changes the ball according to what the player has equipped.
 *  Contributors:       Myles Ceasar
 *  Last Modified:      4/22/22 - Myles Caesar
 */

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChangeBall : MonoBehaviour
{
    public Material skyballMaterial;
    public Material luckyballMaterial;
    public Material cosmicballMaterial;

    private float scaleDown = 0.3f;    //if needed, how much we make the ball smaller
    private float scaleUp = 0.3f;  //if needed, how much we make the ball larger

    private float massDown = 0.5f; //if needed, how much weight we take off the ball
    private float massUp = 0.5f;   //if needed, how much weight we put on the ball

    private Rigidbody ballRB;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = gameObject.GetComponent<Rigidbody>();

        PlayerData data = SaveSystem.LoadPlayer();
        int[] localInventory = data.inventory;
        int index = Array.IndexOf(localInventory, 2);   //Find the ball we should change to

        float scaleX = transform.localScale.x;
        float scaleY = transform.localScale.y;
        float scaleZ = transform.localScale.z;

        switch (index)
        {
            case 0:     //Equip Default Ball
                return;
            case 1:     //Equip Sky Ball
                transform.localScale = new Vector3(scaleX - scaleDown, scaleY - scaleDown, scaleZ - scaleDown); //shrink the ball
                ballRB.mass -= massDown;    //makes the ball weigh less
                gameObject.GetComponent<MeshRenderer>().material = skyballMaterial; //equip sky ball material
                return;
            case 2:     //Equip Lucky Ball
                gameObject.GetComponent<MeshRenderer>().material = luckyballMaterial;   //equip lucky ball material
                return;
            case 3:     //Equip Cosmic Ball
                transform.localScale = new Vector3(scaleX + scaleUp, scaleY + scaleUp, scaleZ + scaleUp);       //enlarge the ball
                ballRB.mass += massUp;  //makes the ball weigh more
                gameObject.GetComponent<MeshRenderer>().material = cosmicballMaterial;  //equip cosmic ball material
                return;
            default:    //No equip ball found
                return;
        }

    }
}
