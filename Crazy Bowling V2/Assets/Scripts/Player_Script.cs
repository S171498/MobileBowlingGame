using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{

    public float speed;
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(boostActive == true)
        {
            Timer += Time.deltaTime;
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