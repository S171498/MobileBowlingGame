using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Test : MonoBehaviour
{

    Rigidbody rb;
    public float force = 5f;
    public float speed = 5f;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        

        if (moveHorizontal != 0.0f)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movement), 0.15F);

            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            /*Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") *force, (CrossPlatformInputManager.GetAxis("Verticle")) * force);
            rb.AddForce(moveVec * force);*/
        }

        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        if (moveVertical != 0.0f)
        {
            Vector3 movement = new Vector3(0, 0.0f, moveVertical);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movement), 0.15F);

            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    }
}
