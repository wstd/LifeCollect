using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MeshNoiser : MonoBehaviour
{
	public bool NoiseNow = false;
	public float NoiseAmount = .2f;
	private Mesh mesh;

	private void Update()
	{
		if (NoiseNow)
		{
			Renoise();
			NoiseNow = false;
		}
	}
	
	private void Renoise()
	{
		mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		int p = 0;
		while (p < vertices.Length)
		{
			vertices[p].y = Random.Range(-NoiseAmount/2, NoiseAmount/2);
			p++;
		}
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
	}
}
