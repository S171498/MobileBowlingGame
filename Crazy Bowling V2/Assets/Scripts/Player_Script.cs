using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    public float boostTime = 1f;
    public float boostPower = 5f;
    public bool boostActive = false;
    public float speed;

    public float Timer;
    public static int Multiplier;
    public int MultiplierShow;

    public Text MultiplierText;
    public RectTransform m_RectTransform;

    public ScoreHolder _ScoreHolder;

    public Transform ballSpawn;
    private Rigidbody rb;

    public Color lerpedColor = Color.green;
    public Color lerpedColor2 = Color.yellow;
    public Color lerpedColor3 = Color.red;

    public int RedValue;
    public int YellowValue;
    public int GreenValue;

    public bool NeutralZone;
    public bool RedZone;
    public bool YellowZone;
    public bool GreenZone;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RedValue = 10;
        YellowValue = 3;
        GreenValue = 1;
        Timer = 0;
        Multiplier = 3;
    }

    void Update()
    {

        lerpedColor = Color.Lerp(Color.green, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor2 = Color.Lerp(Color.yellow, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor3 = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1));
    
        if (RedZone == true)
        {
            _ScoreHolder.AddScore(RedValue * Multiplier);
            MultiplierText.color = lerpedColor3;
            GreenZone = false;
            YellowZone = false;
        }

        if (YellowZone == true)
        {
            _ScoreHolder.AddScore(YellowValue * Multiplier);
            MultiplierText.color = lerpedColor2;
            RedZone = false;
            GreenZone = false;
        }

        if (GreenZone == true)
        {
            _ScoreHolder.AddScore(GreenValue * Multiplier);
            MultiplierText.color = lerpedColor;
            YellowZone = false;
            RedZone = false;
        }

        if(NeutralZone == true)
        {
            MultiplierText.color = Color.black;
        }

        MultiplierText.text = "X" + Multiplier.ToString();

        MultiplierShow = Multiplier;

        // Timer will increase every second, if the timer reaches a certain amount then the multiplier will decrease
        Timer += Time.deltaTime;
        if (Timer < 15)
        {
            Multiplier = 3;
            MultiplierText.fontSize = 80;    
        }
        if (Timer >= 15)
        {
            Multiplier = 2;
            MultiplierText.fontSize = 50;
            
        }
        if (Timer >= 30)
        {
            Multiplier = 1;
            MultiplierText.fontSize = 30;   
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RedZone")
        {
            RedZone = true;
            YellowZone = false;
            GreenZone = false;
            NeutralZone = false;
        }

        if (other.gameObject.tag == "YellowZone")
        {
            YellowZone = true;
            GreenZone = false;
            RedZone = false;
            NeutralZone = false;
        }

        if (other.gameObject.tag == "GreenZone")
        {
            GreenZone = true;
            YellowZone = false;
            RedZone = false;
            NeutralZone = false;
        }

        if (other.gameObject.tag == "ClearMulti" || other.gameObject.tag == "Stop")
        {
            NeutralZone = true;
            RedZone = false;
            YellowZone = false;
            GreenZone = false;
        }

        if(other.gameObject.tag == "ClearMulti")
        {
            Timer = 0;
        }

        if(other.gameObject.tag == "Gutter")
        {
            _ScoreHolder.Score = 0;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    public void Reset(object _ball)
    {
        StartCoroutine(SpawnBall());
        /*gameObject.transform.position = ballSpawn.position;
        gameObject.transform.rotation = ballSpawn.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;*/
    }

    public IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = ballSpawn.position;
        gameObject.transform.rotation = ballSpawn.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

}