using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    
    public void SwipeScene()
    {
        SceneManager.LoadScene("Test_Scene", LoadSceneMode.Single);
    }

    public void JoyScene()
    {
        SceneManager.LoadScene("New_Test", LoadSceneMode.Single);
    }

    public void HoldScene()
    {
        SceneManager.LoadScene("Tap&Hold_Test", LoadSceneMode.Single);
    }

}
