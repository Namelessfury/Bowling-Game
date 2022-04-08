using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "BallTag"){
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
    }
}
