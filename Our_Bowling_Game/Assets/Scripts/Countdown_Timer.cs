using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown_Timer : MonoBehaviour
{
    public float timeReset;
    public float timeLeft;
    public Text countdownText;
    public Pins_Over pins_Over;
    public bool FirstBall;

    private void Awake()
    {
        timeLeft = timeReset;
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        countdownText.text = "" + timeLeft.ToString("F0");

        if (timeLeft <= -0.5f)
        {
            SceneManager.LoadScene("Lane1", LoadSceneMode.Single);
        }
    }

    public void ResetTimer()
    {
        timeLeft = timeReset;
    }
}