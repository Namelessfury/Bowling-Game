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
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject;

        PlayerData data = SaveSystem.LoadPlayer();
        int[] localInventory = data.inventory;
        int index = Array.IndexOf(localInventory, 2);   //Find the ball we should change to

        switch (index)
        {
            case 0:     //Equip Default Ball

                return;
            case 1:     //Equip Sky Ball
                return;
            case 2:     //Equip Lucky Ball
                return;
            case 3:     //Equip Cosmic Ball
                return;
            default:    //No equip ball found
                return;
        }

    }
}
