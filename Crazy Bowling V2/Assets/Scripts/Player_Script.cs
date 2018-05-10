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
    public Transform ballSpawn;
    private Rigidbody rb;
    public ScoreKeeper _ScoreKeeper;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (_ScoreKeeper._Frame > 10)
        {
            Debug.Log("Frame is at 10 and level is finished");
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
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
        gameObject.transform.position = ballSpawn.position;
        gameObject.transform.rotation = ballSpawn.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

}