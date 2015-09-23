// just dummy controller for the object..
// http://unitycoder.com/blog/
//#pragma strict

private var speed:float=0.04;

function Start () {

}

function Update () 
{

	// controls
	if (Input.GetKey ("t"))
	{
		transform.position+=Vector3(0,0,speed);
	}
	if (Input.GetKey ("g"))
	{
		transform.position+=Vector3(0,0,-speed);
	}
	if (Input.GetKey ("f"))
	{
		transform.position+=Vector3(-speed,0,0);
	}
	if (Input.GetKey ("h"))
	{
		transform.position+=Vector3(speed,0,0);
	}

	if (Input.GetKey ("r"))
	{
		transform.position+=Vector3(0,speed,0);
	}
	if (Input.GetKey ("y"))
	{
		transform.position+=Vector3(0,-speed,0);
	}

}