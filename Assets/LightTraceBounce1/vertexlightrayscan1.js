// scan from vertices to light v1.0
// http://unitycoder.com/blog/

#pragma strict

public var light1:Transform;

private var maxdistance:int=15;
private var maxloop:int=128;

private var mesh : Mesh;
private var vertices : Vector3[];
private var verticecount : int;
private var normals : Vector3[];
private var colors : Color[];
private var n:int = 0;


function Start () {
	mesh= GetComponent(MeshFilter).mesh;
	vertices = mesh.vertices;
	verticecount = vertices.Length;
	colors = new Color[vertices.Length];
	//colors =  mesh.colors;
	
//	print (colors.Length);
}

function Update () 
{

	// keep scanning to random directions
	// TODO: scan pixel by pixel with screenpos..(from light to screenpospixel?) and bounce from there if needed..
	// TODO: scan from each vertex! to light.. ? same as shader light? no, if there is block, vertex is black = shadow, if normal is ok, then scan, otherwise black
	
//	var dir:Vector3 = Random.onUnitSphere;
//	var hit : RaycastHit;
//	if (Physics.Raycast (transform.position, dir, hit, maxdistance)) 
//	{
		// we hit something, check bounce factor? add color to this spot (screenpos or local?)
//		Debug.DrawLine (transform.position, hit.point, Color.red,0.1);
//	}

	// vertex scan
	
	
	for (var l:int=0;l<maxloop;l++)
	{
		if (Physics.Linecast (transform.TransformPoint(vertices[n]), light1.position)) 
		{
	//		Debug.DrawLine (transform.TransformPoint(vertices[n]),  light1.position, Color.red,0.1);
			// add smoothing to neighbour vertices?
			colors[n] = Color(0.1,0.1,0.1,1);
		}else{ // no hit
	//		Debug.DrawLine (transform.TransformPoint(vertices[n]),  light1.position, Color.green,0.1);
			colors[n] = Color(1,1,1,1); // dist?
		}
		n = Mathf.Repeat(n+1,verticecount);
	}
	
	
	 mesh.colors = colors;

}