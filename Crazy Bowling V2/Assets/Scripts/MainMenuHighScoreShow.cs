using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHighScoreShow : MonoBehaviour {

    public Text highScoreHolder;
    public float Score;

    // Use this for initialization
    void Start()
    {

        highScoreHolder.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();

    }
	
	// Update is called once per frame
	void Update () {

        if (Score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", Score);
            highScoreHolder.text = "" + Score.ToString("N0");
        }

    }
}
