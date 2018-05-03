using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour {

    public int _ball = 0;
    bool doUpdate = false;

    public void LateUpdate()
    {
        if(doUpdate)
        {
            _ball += 1;
            _ball = _ball % 3;
            StartCoroutine(DelayUpdate());
        }
        doUpdate = false;
    }

    public IEnumerator DelayUpdate()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SendMessage("UpdateScore", _ball, SendMessageOptions.RequireReceiver);
        yield return 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player_Script>() != null || other.gameObject.GetComponent<Mobile_Controls>() != null )
        {
            doUpdate = true;
            other.gameObject.SendMessage("Reset", _ball, SendMessageOptions.DontRequireReceiver);
        }
    }

    //Resets all pins to be back at the start point and resets the frame back to zero.
    public void ResetFrame()
    {
        foreach(var v in GameObject.FindGameObjectsWithTag("Pins"))
        {
            v.SendMessage("ResetPin", (_ball), SendMessageOptions.DontRequireReceiver);
        }
        _ball = 0;
    }
}
