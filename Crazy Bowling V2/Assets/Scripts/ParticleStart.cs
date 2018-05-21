using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{

    public ParticleSystem _ParticleSystem1;

    public int pinCount;
    public float PinValue;
    public float StrikeValue;
    public float PinMult;

    public Transform Pin;
    public ScoreHolder _ScoreHolder;
    public Player_Script _PlayerScript;

    public bool isFallen;
    public bool Strike;
    

    // Use this for initialization
    void Start()
    {
        PinValue = 100;
        StrikeValue = 10000;
    }

    // Update is called once per frame
    void Update()
    {

        if (pinCount == 0)
        {
            _ParticleSystem1.gameObject.SetActive(true);
            Strike = true;
        }

        if (pinCount == 10)
        {
            _ParticleSystem1.gameObject.SetActive(false);
            Strike = false;
        }

        if (Strike == true)
        {
            _ScoreHolder.AddScore(StrikeValue);
            Strike = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pins")
        {
            pinCount++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pins")
        {
            pinCount--;
            _ScoreHolder.AddScore(PinValue * _PlayerScript.ZoneMultiplier * _PlayerScript.Multiplier);
        }
    }
}
