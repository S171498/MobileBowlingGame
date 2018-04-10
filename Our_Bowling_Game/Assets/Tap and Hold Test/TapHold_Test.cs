using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHold_Test : MonoBehaviour {

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    public float speed;
    public float rotateSpeed;
    private Rigidbody rb;
    private float pointer_x;
    private float pointer_y;
    private float holdTime = 0.8f;
    private float acumTime = 0f;

    void Start()
    {
        dragDistance = Screen.height * 5 / 100; //dragDistance is 5% height of the screen
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            acumTime += Input.GetTouch(0).deltaTime;

            if (acumTime >= holdTime)
            {
                //Long tap
                speed += 10;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                acumTime = 0;
                rb.AddForce(Vector3.forward * speed);
                speed = 10;
            }
        }
        Vector3 movement = new Vector3(pointer_x, 0.0f, pointer_y);
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            pointer_x = Input.touches[0].deltaPosition.x;
            pointer_y = Input.touches[0].deltaPosition.y;

            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 5% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            rb.AddForce(Vector3.right * rotateSpeed);
                            //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            rb.AddForce(Vector3.left * rotateSpeed);
                            //transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                            //rb.AddForce(movement * speed); 
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                            //rb.AddForce(movement * speed);
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 5% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }
}
