using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour {

    public Text scoreText;
    public int Score;

    // Use this for initialization
    void Start () {

        Score = 0;
        scoreText.text = "" + Score;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void AddScore (int score)
    {
        Score = Score + score;
        scoreText.text = "" + Score;
    }
}
