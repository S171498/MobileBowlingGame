using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Controls : MonoBehaviour {


    public GameObject player;
    public GameObject pinsCounter;
    //public Touch_Controls touchScript;
    public Player_Script playerScript;
    public Pins_Over pinsScript;
    public Countdown_Timer countdownScript;
    //public Test joystickScript;
    //public TapHold_Test tapHoldScript;

    void Awake () {

        //touchScript = player.GetComponent<Touch_Controls>();
        playerScript = player.GetComponent<Player_Script>();
        pinsScript = pinsCounter.GetComponent<Pins_Over>();
        //joystickScript = player.GetComponent<Test>();
        //tapHoldScript = player.GetComponent<TapHold_Test>();
    }

	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.enabled = false;
            
            //touchScript.enabled = false;
            //joystickScript.enabled = false;
            //tapHoldScript.enabled = false;
            Debug.Log("Stop");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.enabled = true;
            countdownScript.ResetTimer();
            //touchScript.enabled = true;
            //joystickScript.enabled = true;
            //tapHoldScript.enabled = true;
            Debug.Log("Stop");
        }
    }
}
