using UnityEngine;
using System.Collections;

public class ZenParticles : MonoBehaviour 
{
	private Camera mainCamera;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = mainCamera.ScreenToWorldPoint(new Vector3((Screen.width/2), (Screen.height - 50), 1));
	}
}
