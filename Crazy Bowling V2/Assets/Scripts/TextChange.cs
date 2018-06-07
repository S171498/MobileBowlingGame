using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {

    public Text TitleText;
    public Text HighscoreText;
    public Text HighscoreNumbers;
    public Text PlayText;

    public Color lerpedColor = Color.blue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        lerpedColor = Color.Lerp(Color.blue, Color.red, Mathf.PingPong(Time.time, 1));

        TitleText.color = lerpedColor;
        HighscoreText.color = lerpedColor;
        HighscoreNumbers.color = lerpedColor;
        PlayText.color = lerpedColor;

    }
}
