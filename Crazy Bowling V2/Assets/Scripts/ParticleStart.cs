using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour {

    public ParticleSystem _ParticleSystem1;
    public int pinCount;
    public int PinValue;
    public ScoreHolder _ScoreHolder;

    // Use this for initialization
    void Start () {

        PinValue = 10;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(pinCount == 0)
        {
            _ParticleSystem1.gameObject.SetActive(true);
        }

        if(pinCount == 10)
        {
            _ParticleSystem1.gameObject.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pins")
        {
            pinCount++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Pins")
        {
            pinCount--;
            _ScoreHolder.AddScore(PinValue * 10);
        }

    }
}
