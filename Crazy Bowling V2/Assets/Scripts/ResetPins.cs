﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPins : MonoBehaviour {

    public Vector3 position;
    public Quaternion rotation;

    void OnEnable()
    {
        position = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Explosion")
        {
            StartCoroutine(SpawnPins());
        }
    }

    public void ResetPin(object _ball)
    {
        //StartCoroutine(SpawnPins());
        /*gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;*/
    }

    public IEnumerator SpawnPins()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
