/*  File Name:         ItemIsHit.cs  
 *  Purpose:           Manages the sound effects of objects when hit with the bowling ball. 
 *  Contributors:      Ashley Mojica
 *  Last Modified:     4/20/2022 - Ashley Mojica
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIsHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //If the item is hit by the bowling ball
        if (other.gameObject.tag == "BallTag")
        {
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
    }
}
