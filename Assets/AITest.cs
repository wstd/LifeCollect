using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AITest : MonoBehaviour
{
	public List<Transform> NavPoints;

	private NavMeshAgent agent;
	private int pointIndex = 0;
	
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();

		agent.destination = NavPoints[pointIndex].position;
	}

	void Update ()
	{
		Vector2 myPos = new Vector2(transform.position.x, transform.position.z);
		Vector2 pointPos = new Vector2(NavPoints[pointIndex].position.x, NavPoints[pointIndex].position.z);

		if (Vector2.Distance(myPos, pointPos) < .1f)
		{
			pointIndex = (pointIndex == NavPoints.Count-1) ? 0 : (pointIndex + 1);
			agent.destination = NavPoints[pointIndex].position;
		}
	}
}
