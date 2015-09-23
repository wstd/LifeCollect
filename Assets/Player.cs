using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Rigidbody body;
	private Light pointLight;

	void Start ()
	{
		body = GetComponent<Rigidbody>();
		pointLight = GetComponentInChildren<Light>();
	}

	void Update ()
	{
		body.velocity = (
			(Vector3.right * Input.GetAxis ("Horizontal") +
			Vector3.forward * Input.GetAxis ("Vertical")) * 5);

		Collider[] colliders = Physics.OverlapSphere(transform.position, pointLight.range);
		foreach (Collider col in colliders)
		{
			Mesh mesh = col.GetComponent<MeshFilter> ().mesh;
			Vector3[] vertices = mesh.vertices;
			Color32[] colors = new Color32[vertices.Length];
			int p = 0;
			while (p <= (vertices.Length-1))
			{
				colors[p] = Physics.Linecast(transform.position, col.transform.InverseTransformPoint(vertices[p]))
					? new Color32(0, 0, 0, 1) :
					  new Color32(0, 0, 1, 1);
				p++;
			}
			mesh.colors32 = colors;
		}
	}
}
