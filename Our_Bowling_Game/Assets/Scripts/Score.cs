using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {
    public int highScore;
    public Text HighScore;

    void Awake()
    {
        
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", + highScore);
    }

	// Update is called once per frame
	void Update ()
    {
        highScore = PlayerPrefs.GetInt("highScore", + highScore);
        HighScore.text = "High Score " + highScore;
    }
}
