using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour {

    public Text scoreText;
    public RectTransform m_RectTransform;
    public int Score;

    public Player_Script _Player_Script;
    public Color lerpedColor = Color.green;
    public Color lerpedColor2 = Color.yellow;
    public Color lerpedColor3 = Color.red;

    // Use this for initialization
    void Start () {

        Score = 0;
        scoreText.text = "" + Score;
    }
	
	// Update is called once per frame
	void Update () {

        
        lerpedColor = Color.Lerp(Color.green, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor2 = Color.Lerp(Color.yellow, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor3 = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1));

        if (_Player_Script.RedZone == true)
        {
            scoreText.color = lerpedColor3;
        }
        if (_Player_Script.YellowZone == true)
        {
            scoreText.color = lerpedColor2;
        }
        if (_Player_Script.GreenZone == true)
        {
            scoreText.color = lerpedColor;
        }
        if(_Player_Script.NeutralZone == true)
        {
            scoreText.color = Color.black;
        }


        if (Score > 100)
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

        scoreText.text = "" + Score;
    }

    public void AddScore (int score)
    {
        Score = Score + score;
        scoreText.text = "" + Score;
    }
}
