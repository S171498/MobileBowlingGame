using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndQuit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Lane1", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
