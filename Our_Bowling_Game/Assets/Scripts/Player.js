#pragma strict

var speed: float;
var thrust: float;
var rb: Rigidbody;



function Start() 
{
	rb= GetComponent.<Rigidbody>();
}

function Update () {
			
}

function FixedUpdate () {

var moveHorizontal : float = Input.GetAxis ("Horizontal");
var moveVertical : float = Input.GetAxis ("Vertical");

var movement = Vector3(moveHorizontal, 0.0f, moveVertical);
rb.AddForce (movement * speed);									
}

