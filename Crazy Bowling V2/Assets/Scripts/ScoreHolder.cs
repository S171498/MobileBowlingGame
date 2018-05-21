using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour {

    public Text scoreText;
    public RectTransform m_RectTransform;
    public Text highScoreHolder;
    public Text nameText;
    public float Score;
    public float ScoreMult;

    public ParticleStart _ParticleStart;
    public Player_Script _PlayerScript;

    public Color lerpedColor = Color.green;
    public Color lerpedColor2 = Color.yellow;
    public Color lerpedColor3 = Color.red;

    // Use this for initialization
    void Start()
    {
        highScoreHolder.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        scoreText.text = "" + Score;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "" + Score;

        lerpedColor = Color.Lerp(Color.green, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor2 = Color.Lerp(Color.yellow, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor3 = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1));

        if (_PlayerScript.RedZone == true)
        {
            scoreText.color = lerpedColor3;
        }
        if (_PlayerScript.YellowZone == true)
        {
            scoreText.color = lerpedColor2;
        }
        if (_PlayerScript.GreenZone == true)
        {
            scoreText.color = lerpedColor;
        }
        if(_PlayerScript.NeutralZone == true)
        {
            scoreText.color = Color.black;
        }

        if (Score > 100)
        {
            scoreText.fontSize = 30;
        }

        if (Score > 1000)
        {
            scoreText.fontSize = 50;
        }

        if (Score > 5000)
        {
            scoreText.fontSize = 60;
        }

        if (Score > 10000)
        {
            scoreText.fontSize = 80;
        }


        if (Score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", Score);
            highScoreHolder.text = "" + Score.ToString("N0");
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("High Score Reset");
    }

    public void AddScore(float score)
    {
        Score = Score + score;
        scoreText.text = "" + Score;
    }
}
