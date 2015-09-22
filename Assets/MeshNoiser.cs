using UnityEngine;
using System.Collections;

public class MeshNoiser : MonoBehaviour
{

	private Mesh mesh;

	// Use this for initialization
	void Start ()
	{
		//StartCoroutine(Renoise());
	}

	private void Update()
	{
		transform.Rotate(Vector3.up);
	}
	
	private IEnumerator Renoise()
	{
		while (true)
		{
			mesh = GetComponent<MeshFilter>().mesh;
			Vector3[] vertices = mesh.vertices;
			int p = 0;
			while (p < vertices.Length)
			{
				vertices[p].y = Random.Range(-.3f, .3f);
				p++;
			}
			mesh.vertices = vertices;
			mesh.RecalculateNormals();
			yield return new WaitForSeconds(Random.Range(.05f, .3f));
		}
	}
}
