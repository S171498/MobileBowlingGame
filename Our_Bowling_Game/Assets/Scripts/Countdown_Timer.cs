using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    }
}