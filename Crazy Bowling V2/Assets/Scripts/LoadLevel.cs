using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        		
	}

    public void LoadLane1()
    {
        SceneManager.LoadScene("Lanes_TEST_LANELENGTHS", LoadSceneMode.Single);
    }

    public void LoadLane2()
    {
        SceneManager.LoadScene("Lanes_TEST_OBSTACLETYPES", LoadSceneMode.Single);
    }
}
