﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallReturn : MonoBehaviour {

    public int _ball = 0;
    public bool doUpdate = false;

    public float GameTimer = 0;
    public Text timer;

    // Use this for initialization
    void Start()
    {

        GameTimer = 30f;
    }

    // Update is called once per frame
    void Update()
    {

        GameTimer -= Time.deltaTime;

        timer.text = "Time Left: " + GameTimer.ToString("N0");

        if (GameTimer < 1 )
        {
            doUpdate = true;
        }

        if(GameTimer < 10 )
        {
            timer.color = Color.red;
        }

        if(GameTimer > 10)
        {
            timer.color = Color.blue;
        }
    }

    public void LateUpdate()
    {
        if(doUpdate)
        {
            _ball += 1;
            _ball = _ball % 3;
            StartCoroutine(DelayUpdate());
            GameTimer = 30;
        }
        doUpdate = false;
    }

    public IEnumerator DelayUpdate()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SendMessage("UpdateScore", _ball, SendMessageOptions.RequireReceiver);
        GameTimer = 30f;
        yield return 0;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player_Script>() != null || other.gameObject.GetComponent<Mobile_Controls>() != null )
        {
            doUpdate = true;
            other.gameObject.SendMessage("Reset", _ball, SendMessageOptions.DontRequireReceiver);
        }
    }

    //Resets all pins to be back at the start point and resets the frame back to zero.
    public void ResetFrame()
    {
        foreach(var v in GameObject.FindGameObjectsWithTag("Pins"))
        {
            v.SendMessage("ResetPin", (_ball), SendMessageOptions.DontRequireReceiver);
        }
        _ball = 0;
    }
}
