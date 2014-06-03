using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour 
{
	public float moveSpeed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").GetComponent<Transform>().position, Time.deltaTime * moveSpeed);
	}
}
