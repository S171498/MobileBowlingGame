#pragma strict

								//JP's line of code (9,10, 13, 30-36)
								//AM's line of code (5-7, 14, 17-27)
public var speed: float;
public var thrust: float;
private var rb: Rigidbody;

var pointScore: int=0;
var scoreLabel : UI.Text;

function Start () {
	pointScore = 0;
	rb= GetComponent.<Rigidbody>();
}

function Update () {
scoreLabel.text = pointScore.ToString("Score: " + pointScore + "/5");			
}

function FixedUpdate () {

var moveHorizontal : float = Input.GetAxis ("Horizontal");
var moveVertical : float = Input.GetAxis ("Vertical");

var movement = Vector3(moveHorizontal, 0.0f, moveVertical);
rb.AddForce (movement * speed);									
}

function OnTriggerEnter (other:Collider){											
if (other.tag == "Collectible")														
{																					
pointScore++;																		
Destroy(other.gameObject);															
}
}