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
    public float Multiplier;
    //public float MultiplierShow;

    public Text MultiplierText;
    public RectTransform m_RectTransform;
    public Text MultiplierZone;

    public ScoreHolder _ScoreHolder;

    public Transform ballSpawn;
    private Rigidbody rb;

    public Color lerpedColor = Color.green;
    public Color lerpedColor2 = Color.yellow;
    public Color lerpedColor3 = Color.red;

    public int RedValue;
    public int YellowValue;
    public int GreenValue;
    public int ZoneMultiplier;
    

    public bool NeutralZone;
    public bool RedZone;
    public bool YellowZone;
    public bool GreenZone;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RedValue = 10;
        YellowValue = 5;
        GreenValue = 1;
        Timer = 30;
        Multiplier = Timer;
        ZoneMultiplier = 0;
    }

    void Update()
    {
        Multiplier = Timer;
        lerpedColor = Color.Lerp(Color.green, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor2 = Color.Lerp(Color.yellow, Color.black, Mathf.PingPong(Time.time, 1));
        lerpedColor3 = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1));



        if (RedZone == true)
        {
            //_ScoreHolder.AddScore(RedValue);
            ZoneMultiplier = 3;
            MultiplierZone.color = lerpedColor3;
        }
        if (YellowZone == true)
        {
            //_ScoreHolder.AddScore(YellowValue);
            ZoneMultiplier = 2;
            MultiplierZone.color = lerpedColor2;
        }
        if (GreenZone == true)
        {
            //_ScoreHolder.AddScore(GreenValue);
            ZoneMultiplier = 1;
            MultiplierZone.color = lerpedColor;
        }

        if (Timer <= 1)
        {
            Timer = 0;
            MultiplierText.color = Color.red;
        }

        if(Timer <= 10)
        {
            MultiplierText.color = lerpedColor3;
        }

        MultiplierText.text = "" + Multiplier.ToString();
        MultiplierZone.text = "X" + ZoneMultiplier;

        //MultiplierShow = Multiplier;

        // Timer will increase every second, if the timer reaches a certain amount then the multiplier will decrease
        if (Timer > 1)
        {
            Timer -= Time.deltaTime;
        }

        Timer = Mathf.Round(Timer * 100f) / 100f;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedZone")
        {
            RedZone = true;
            YellowZone = false;
            GreenZone = false;
            NeutralZone = false;
        }

        if (other.gameObject.tag == "YellowZone")
        {
            YellowZone = true;
            RedZone = false;
            GreenZone = false;
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

        if (other.gameObject.tag == "ClearMulti")
        {
            Timer = 30;
            ZoneMultiplier = 0;
            MultiplierZone.color = Color.black;
            MultiplierText.color = Color.black;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Transform cameraTransform = Camera.main.transform;

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0.0f;
        camForward.Normalize();

        Vector3 camRight = Vector3.Cross(camForward, -Vector3.up);

        Vector3 betterMovement = camForward * moveVertical + camRight * moveHorizontal;

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(betterMovement * speed);
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