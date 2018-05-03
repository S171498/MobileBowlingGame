using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    public ScoreKeeper _ScoreKeeper;
    public ScoreKeeper _ScoreKeeper2;
    public Text frame;
    public Text score;
    public Text ball;

    void Update()
    {
        frame.text = "Turn: " + _ScoreKeeper._Frame.ToString();
        score.text = "Score: " + _ScoreKeeper._Score.ToString();
        ball.text = "Bowl: " + _ScoreKeeper._FrameBall.ToString();
        frame.text = "Turn: " + _ScoreKeeper2._Frame.ToString();
        score.text = "Score: " + _ScoreKeeper2._Score.ToString();
        ball.text = "Bowl: " + _ScoreKeeper2._FrameBall.ToString();
    }

}
