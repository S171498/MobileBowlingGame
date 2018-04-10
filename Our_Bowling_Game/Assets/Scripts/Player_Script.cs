using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Script: MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    public Pins_Over pins_Over;

    public bool FirstBall;
    public bool SecondBall;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FirstBall = true;
        SecondBall = false;
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
        if (other.gameObject.tag == "GutterBall" && FirstBall == true)
        {
            FirstBall = false;
            FirstBowl();
        }
        else if (other.gameObject.tag == "GutterBall" && FirstBall == false)
        {
            SecondBowl();
            SecondBall = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FirstBowl()
    {
        pins_Over.FirstBall();   
    }

    public void SecondBowl()
    {
        if (SecondBall == true)
        {
            pins_Over.SecondBall();
        }
    }
}