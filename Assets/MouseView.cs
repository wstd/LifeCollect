using UnityEngine;
using System.Collections;

public class MouseView : MonoBehaviour
{

	private Vector3 startPos;

	void Start ()
	{
		startPos = transform.position;
	}

	void Update ()
	{
		transform.position = startPos - new Vector3(
			Input.mousePosition.x - (float)Screen.width / 2,
			0,
			Input.mousePosition.y - (float)Screen.height / 2) * .01f;
	}
}
