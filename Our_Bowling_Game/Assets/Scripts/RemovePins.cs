using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePins : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        StartDestroyPins(); 
        Debug.Log("Start Destroy Pins");
    }

    void StartDestroyPins()
    {
        StartCoroutine(DestroyPins());
    }

    IEnumerator DestroyPins()
    {
        Debug.Log("Destroy");
        //this.GetComponent<BoxCollider>().enabled = false;
        
        yield return new WaitForSeconds(2);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
