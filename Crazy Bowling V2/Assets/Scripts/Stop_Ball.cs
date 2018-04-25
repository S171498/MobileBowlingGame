using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Ball : MonoBehaviour {

    public Player_Script _Player_Script;
    public Transform ballSpawn;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            _Player_Script.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            _Player_Script.enabled = true;
        }
    }

    public void Reset(object _ball)
    {
        gameObject.transform.position = ballSpawn.position;
        gameObject.transform.rotation = ballSpawn.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
