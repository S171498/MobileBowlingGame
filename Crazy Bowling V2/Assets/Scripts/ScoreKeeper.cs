using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public List<BowlingFrame> Frames = new List<BowlingFrame>();

    public int _Frame;
    public int _Down;
    public int _FrameBall = 0;
    public int _Score;
    public BallReturn _BallReturn;

    HashSet<int> DownPins = new HashSet<int>();

    void Start()
    {
        DownPins.Clear();
        Frames.Add(new BowlingFrame(0));
    }

   /* void Update()
    {
        if(_BallReturn.GameTimer < 0)
        {
            _BallReturn.GameTimer = 30;
            NewFrame();
        }
    }*/

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
        BowlingFrame bf = Frames[Frames.Count - 1].AddScore(_FrameBall, _Down);
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
        _Score = BowlingFrame.Score(Frames);
    }

}

public class BowlingFrame
{
    int Score1 = 0;
    int Score2 = 0;
    int Carry;

    public BowlingFrame(int carries)
    {
        Carry = carries;
    }

    public BowlingFrame AddScore(int ball, int score)
    {
        if (ball == 0)
        {
            //Checks if the score is 10 then adds a new frame.
            Score1 = Mathf.Max(score, 0);
            if(score == 10)
            {
                return new BowlingFrame(2);
            }
            return null;
        }
        else
        {
            //This does the same as above but it checks if both scores added are equal to 10.
            Score2 = score - Score1;    
            if(Score1 + Score2 == 10)
            {
                return new BowlingFrame(1);
            }
            return new BowlingFrame(0);
        }
    }

    public static int Score(IEnumerable<BowlingFrame> frames)
    {
        int score = 0;
        foreach (BowlingFrame f in frames)
        {
            score += f.Score1;
            score += f.Score2;
            if (f.Carry > 0) score += f.Score1;
            if (f.Carry > 1) score += f.Score2;
        }

        return score;
    }
}
