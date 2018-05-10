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
        SceneManager.LoadScene("Lane_Level_01", LoadSceneMode.Single);
    }

}
