using UnityEngine;
using System.Collections;

public class DoorLabel : MonoBehaviour 
{
	private Transform player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.LookAt(player.position);
	}
}
