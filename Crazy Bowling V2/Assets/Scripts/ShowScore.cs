using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    public ScoreKeeper _ScoreKeeper;
    public Text frame;
    public Text score;
    public Text ball;

    void Update()
    {
        frame.text = "Frame: " + _ScoreKeeper._Frame.ToString();
        score.text = "Score: " + _ScoreKeeper._Score.ToString();
        ball.text = "Ball: " + _ScoreKeeper._FrameBall.ToString();
    }

}
