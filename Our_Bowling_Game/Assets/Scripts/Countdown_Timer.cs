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

        if (timeLeft <= 10.5)
        {
            countdownText.color = new Color32(255, 0, 0, 255);
        }
    }

    public void ResetTimer()
    {
        timeLeft = timeReset;
    }
}