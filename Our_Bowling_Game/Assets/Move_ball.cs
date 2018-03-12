using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ball : MonoBehaviour {

    public float horizontalSpeed = 0.5f;
    public float verticalSpeed = 0.5f;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            var h = horizontalSpeed * Input.GetAxis("Mouse Y");
            var v = verticalSpeed * Input.GetAxis("Mouse X");
            transform.Translate(v, h, 0);
        }
    }
}
