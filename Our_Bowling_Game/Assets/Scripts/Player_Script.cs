using UnityEngine;
using System.Collections;

public class Player_Script: MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    public Pins_Over pins_Over;



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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GutterBall")
        {
            FirstBowl();
        }
    }

    public void FirstBowl()
    {
        pins_Over.FirstBall();
    }
}