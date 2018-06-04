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

    void Awake()
    {
        _ScoreHolder.Score = 0;
    }

    // Use this for initialization
    void Start()
    {
        PinValue = 100;
        StrikeValue = 10000;
        _ScoreHolder.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pinCount == 0)
        {
            _ParticleSystem1.gameObject.SetActive(true);
            _ScoreHolder.AddScore(StrikeValue);
            //StrikeCount = StrikeCount + 1;
        }

        if (pinCount == 10)
        {
            _ParticleSystem1.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pins")
        {
            pinCount = pinCount + 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pins")
        {
            pinCount = pinCount - 1;
            _ScoreHolder.AddScore(PinValue * _PlayerScript.ZoneMultiplier * _PlayerScript.Multiplier);
        }
    }
}
