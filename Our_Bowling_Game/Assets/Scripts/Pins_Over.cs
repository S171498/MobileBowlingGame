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
    //public GameObject pinsPanel;
    public Text strikeText;
    public Text pinsHit;
    public Text roundScore;
    //public Text HighScore;
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
        //pinsPanel.SetActive(true);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Test_Scene"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (fallen == 1 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 1 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 2 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 2 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 3 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 3 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 4 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 4 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 5 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 5 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 6 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 6 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 7 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 7 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 8 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
        }
        else if (fallen == 8 && secondBowl == true)
        {
            StartCoroutine(SecondBowl());
        }

        if (fallen == 9 && firstBowl == true)
        {
            StartCoroutine(FirstBowl());
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
            StartCoroutine(LevelFinished());
        }

        roundScore.text = "Score " + score;
        //HighScore.text = "High Score " + highScore;

    }

    IEnumerator FirstBowl()
    {
        pinsHit.text = "Pins " + fallen;
        yield return new WaitForSeconds(2);
        player.transform.position = playerPosition;
        firstBowl = false;
        secondBowl = true;
    }

    IEnumerator SecondBowl()
    {
        pinsHit.text = "Pins " + fallen;
        Debug.Log("Pins " + fallen);
       yield return new WaitForSeconds(5);
        //SceneManager.LoadScene("Test_Scene", LoadSceneMode.Single);
    }

    IEnumerator LevelFinished()
    {
        //pinsPanel.SetActive(false);
        pinsHit.text = "Spare";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("New_Test", LoadSceneMode.Single);
        
    }

    IEnumerator Strike()
    {
        strikePanel.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("New_Test", LoadSceneMode.Single);
    }

    void OnTriggerExit(Collider other)
    {
        fallen ++;
        score += 10;
        highScore += 10;
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();
    }
}
