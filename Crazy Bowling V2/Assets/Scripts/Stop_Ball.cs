using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Ball : MonoBehaviour {

    public Player_Script _Player_Script;
    public Camera_Controller _Camera_Controller;
    public Area_Control _Area_Control;

    public Transform ballSpawn;

    public Transform cameraSpawn;

    public GameObject Camera;

    // Use this for initialization
    void Start()
    {
        _Area_Control.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            _Player_Script.enabled = false;
            _Camera_Controller.enabled = false;
            _Area_Control.enabled = true;
        }

        if(other.gameObject.tag == "CameraReset")
        {
            _Camera_Controller.enabled = true;
            Camera.transform.position = cameraSpawn.position;
            Camera.transform.rotation = cameraSpawn.rotation;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            _Player_Script.enabled = true;
            _Area_Control.enabled = false;
        }
    }

}
