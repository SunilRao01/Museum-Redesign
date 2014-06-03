using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour 
{
	private GameObject playerObject;
	private Vector3 playerPosition;

	// Use this for initialization
	void Start () 
	{
		playerObject = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerPosition = playerObject.transform.position;

		transform.LookAt(playerPosition);

		Vector3 newRotation = transform.rotation.eulerAngles;
		newRotation.y += 90;
		transform.Rotate(Vector3.up * 90);

		//transform.right = playerPosition;
		// TODO: Make Main thought bubble look at player (billboardinfdsa

	}
}
