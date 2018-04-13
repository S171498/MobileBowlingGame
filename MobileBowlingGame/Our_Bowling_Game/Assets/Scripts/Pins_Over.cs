using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pins_Over : MonoBehaviour {

    public int fallen = 0;
    public int score = 0;
    public int highScore = 0;
    public GameObject strikePanel;
    public GameObject pinsPanel;
    public Text strikeText;
    public Text pinsHit;
    //public Text roundScore;
    public Text HighScore;
    public bool firstBowl;
    public bool secondBowl;
    public GameObject player;

    public Vector3 playerPosition;  // Records player position at start of level

    // Use this for initialization
    void Start () {

        firstBowl = true;
        secondBowl = false;
        highScore = PlayerPrefs.GetInt("highScore", +highScore);
    }

    void Awake() {
        playerPosition = player.transform.position;
        strikePanel.SetActive(false);
        pinsPanel.SetActive(false);
        //pinsPanel.SetActive(true);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Lane1"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (fallen == 1 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 1 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 2 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 2 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 3 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 3 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 4 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 4 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 5 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 5 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 6 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 6 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 7 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 7 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 8 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 8 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 9 && firstBowl == true)
        {
            FirstBall();
        }
        else if (fallen == 9 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 10 && firstBowl == true)
        {
            Debug.Log("Strike!");
            StartCoroutine (Strike());
        }
        else if (fallen == 10 && secondBowl == true)
        {
           StartCoroutine(Spare());
        }

        //roundScore.text = "Score " + score;
        HighScore.text = "Score " + highScore;

    }

    public void FirstBall()
    {
        StartCoroutine(FirstBowl());
    }

    public void SecondBall()
    {
        //StartCoroutine(GutterBall());
        StartCoroutine(SecondBowl());
    }
    
    IEnumerator ShowPins()
    {
        pinsPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        pinsPanel.SetActive(false);
    }

    IEnumerator FirstBowl()
    {
        //pinsHit.text = "Pins " + fallen;
        //StartCoroutine(ShowPins());
        yield return new WaitForSeconds(2);
        player.transform.position = playerPosition;
        firstBowl = false;
        secondBowl = true;
        fallen = 0;
    }

    IEnumerator SecondBowl()
    {
        //pinsHit.text = "Pins " + fallen;
        //StartCoroutine(ShowPins());
        Debug.Log("Pins " + fallen);
       yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator GutterBall()
    {
        StartCoroutine(ShowPins());
        yield return new WaitForSeconds(2);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //player.transform.position = playerPosition;
        secondBowl = true;
        fallen = 0;
    }

    IEnumerator Spare()
    {
        //pinsPanel.SetActive(false);
        pinsHit.text = "Spare";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Strike()
    {
        strikePanel.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerExit(Collider other)
    {
        fallen ++;
        score += 1;
        highScore += 1;
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();
    }
}
