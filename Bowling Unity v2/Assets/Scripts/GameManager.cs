using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    GameObject[] pins;

    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pins");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            CountPinsDown();
        }
    }

    void CountPinsDown(){
        for(int i = 0; i < pins.Length; i++){
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z > 355 ){
                score++;
                //pins[i].SetActive(false);
            }
        }
        Debug.Log(score);
    }
}
