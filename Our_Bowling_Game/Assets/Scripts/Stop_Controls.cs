﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Controls : MonoBehaviour {


    public GameObject player;
    public GameObject pinsCounter;
    public Touch_Controls touchScript;
    public Player_Script playerScript;
    public Pins_Over pinsScript;
    public Test joystickScript;

    void Awake () {

        touchScript = player.GetComponent<Touch_Controls>();
        playerScript = player.GetComponent<Player_Script>();
        pinsScript = pinsCounter.GetComponent<Pins_Over>();
        joystickScript = player.GetComponent<Test>();
    }

	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.enabled = false;
            touchScript.enabled = false;
            joystickScript.enabled = false;
            Debug.Log("Stop");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.enabled = true;
            touchScript.enabled = true;
            joystickScript.enabled = true;
            Debug.Log("Stop");
        }
    }
}
