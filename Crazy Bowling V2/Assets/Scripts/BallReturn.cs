using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour {

    public int _ball = 0;
    bool doUpdate = false;

    void LateUpdate()
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
        yield return new WaitForSeconds(.5f);
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

    void ResetFrame()
    {
        foreach(var v in GameObject.FindGameObjectsWithTag("Pins"))
        {
            v.SendMessage("ResetPin", (_ball), SendMessageOptions.DontRequireReceiver);
        }
        _ball = 0;
    }
}
