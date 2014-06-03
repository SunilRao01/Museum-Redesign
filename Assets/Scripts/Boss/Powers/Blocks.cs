using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour 
{
	public Material solidMaterial;

	// Use this for initialization
	void Start () 
	{
		renderer.material = solidMaterial;
		
		
		
		Destroy(this);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
