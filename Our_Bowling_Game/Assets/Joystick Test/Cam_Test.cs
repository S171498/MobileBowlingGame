﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Test : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Update()
    {
        //transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}