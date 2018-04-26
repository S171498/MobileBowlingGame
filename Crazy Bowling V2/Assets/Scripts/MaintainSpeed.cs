using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainSpeed : MonoBehaviour {

    public int constantSpeed = 5;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            rb.velocity = constantSpeed * (rb.velocity.normalized); 
        }
    }
}
