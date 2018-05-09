using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public List<Start> Frames = new List<Start>();

    public int _Frame;
    public int _Down;
    public int _FrameBall = 0;
    public int _Score;
    public float Timer;
    public static int Multiplier;
    public int MultiplierShow;

    public Text TimerText;
    public Text MultiplierText;
    
    // public BallReturn _BallReturn; May no longer be needed?

    HashSet<int> DownPins = new HashSet<int>();

    void Start()
    {
        DownPins.Clear();
        Frames.Add(new Start(0));
        Timer = 0;
        Multiplier = 3;
    }

  void Update()
    {

        TimerText.text = "Time: " + Timer.ToString("N0");
        MultiplierText.text = "Multipler: " + Multiplier.ToString();

        MultiplierShow = Multiplier;
        
        // Timer will increase every second, if the timer reaches a certain amount then the multiplier will decrease
        Timer += Time.deltaTime;
        if (Timer < 15)
        {
            Multiplier = 3;
        }
        if (Timer >= 15)
        {
            Multiplier = 2;
        }
        if (Timer >= 30)
        {
            Multiplier = 1;
        }


        /* Commenting this out, may no longer be needed? 
        if(_BallReturn.GameTimer < 0)
        {
            _BallReturn.GameTimer = 30;
            NewFrame();
        }
        */

    
    }

    int getDownPins()
    {
        //This finds all pins, and then checks if they are moving or if the uv is below a certain point to count them as down.
        int down = 0;       
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Pins"))
        {
            if(g.GetComponent<Rigidbody>().velocity.magnitude < .1f)
            {
                Matrix4x4 m = g.transform.localToWorldMatrix;
                Vector3 uv = m.MultiplyVector(Vector3.up).normalized;

                if (uv.y < .707)
                {
                    down += 1;
                }
                continue;
            }
            if(g.transform.position.y < 0 || g.transform.position.z > 1 || g.transform.position.z > -1)
            {
                down += 1;
                continue;
            }            
        }
        return down;
    }

    public void UpdateScore(object ball)
    {
        //Gets all down pins and updates the score and the frame.
        _Down = getDownPins();
        Start bf = Frames[Frames.Count - 1].AddScore(_FrameBall, _Down);
        _FrameBall += 1;

        if (bf != null)
        {
            Frames.Add(bf);
            NewFrame();
        }
    }

    public void NewFrame()
    {
        //Adds a new frame to the counter and resets everything.
        _FrameBall = 0;
        _Frame = Frames.Count;
        DownPins.Clear();
        gameObject.SendMessage("ResetFrame", SendMessageOptions.RequireReceiver);
        _Score = global::Start.Score(Frames);
        Timer = 0; // This will only reset the timer and multiplier after the 2nd shot
    }

}

public class Start
{
    int Score1 = 0;
    int Score2 = 0;
    int Carry;
    
    public Start(int carries)
    {
        Carry = carries;
    }

    public Start AddScore(int ball, int score)
    {
        if (ball == 0)
        {
            //Checks if the score is 10 then adds a new frame.
            Score1 = Mathf.Max(score, 0);
            if(score == 10)
            {
                return new Start(2);
            }
            return null;
        }
        else
        {
            //This does the same as above but it checks if both scores added are equal to 10.
            Score2 = score - Score1;    
            if(Score1 + Score2 == 10)
            {
                return new Start(1);
            }
            return new Start(0);
        }
    }

    public static int Score(IEnumerable<Start> frames)
    {
        int score = 0;
        foreach (Start f in frames)
        {
            score += f.Score1 * ScoreKeeper.Multiplier; // Will multiply the first shot with the multiplier (Buggy, doesn't work properly, where else does the score work?)
            score += f.Score2;                          // However should only add the amount knocked down for the second shot
            if (f.Carry > 0) score += f.Score1;
            if (f.Carry > 1) score += f.Score2;
        }

        return score;
    }
}
