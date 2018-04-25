using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    public float boostTime = 1f;
    public float boostPower = 0f;
    public float Timer = 0f;
    public bool boostActive = false;
    public float speed;
    public Transform ballSpawn;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        

        if (boostActive == true)
        {
            Timer += Time.deltaTime;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Timer >= boostTime)
        {
            speed = 5f;
            Timer = 0f;
            boostActive = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost")
        {
            speed = boostPower;
            boostActive = true;
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
