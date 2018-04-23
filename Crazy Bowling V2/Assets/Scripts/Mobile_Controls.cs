using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile_Controls : MonoBehaviour {

    public float speed = 5f;
    public float boostTime = 1f;
    public float boostPower = 30f;
    public float Timer = 0f;
    public bool boostActive = false;
    public Transform ballSpawn;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (boostActive == true)
        {
            Timer += Time.deltaTime;
        }

        if (Timer >= boostTime)
        {
            speed = speed * 2;
            Timer = 0f;
            boostActive = false;
        }

    }

    void Update()
    {
        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed * 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost")
        {
            speed = boostPower;
            boostActive = true;
        }
    }
}
