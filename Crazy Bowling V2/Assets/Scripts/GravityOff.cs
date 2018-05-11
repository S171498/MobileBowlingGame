using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOff : MonoBehaviour {

    public Rigidbody _Rigidbody;
    public float thrust;

	// Use this for initialization
	void Start () {

        thrust = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Explosion")
        {
            //_Rigidbody.useGravity = false;
            _Rigidbody.AddForce(transform.up * thrust);


        }
    }
}
