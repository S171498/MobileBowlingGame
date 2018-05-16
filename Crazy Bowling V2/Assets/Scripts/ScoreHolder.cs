using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour {

    public Text scoreText;
    public RectTransform m_RectTransform;
    public int Score;

    public Color lerpedColor = Color.green;

    // Use this for initialization
    void Start () {

        Score = 0;
        scoreText.text = "" + Score;
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.color = lerpedColor;
        lerpedColor = Color.Lerp(Color.green, Color.black, Mathf.PingPong(Time.time, 1));

        if(Score > 100)
        {
            scoreText.fontSize = 30;
        }

        if(Score > 1000)
        {
            scoreText.fontSize = 50;
        }

        if(Score > 5000)
        {
            scoreText.fontSize = 60;
        }

        if(Score > 10000)
        {
            scoreText.fontSize = 80;
        }
    }

    public void AddScore (int score)
    {
        Score = Score + score;
        scoreText.text = "" + Score;
    }
}
