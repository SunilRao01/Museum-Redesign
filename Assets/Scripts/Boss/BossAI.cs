using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour 
{
	public Vector3 playerPostiion;
	public GameObject playerObject;
	public float turnForce;

	void Start () 
	{
		//iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Main Boss Path"), "time", 100, "orienttopath", true, "looktime", 2.0f));
		playerObject = GameObject.Find("Player");
	}
	
	void Update () 
	{
		handleMovement();
	}

	// Boss moving
	void handleMovement()
	{
		playerPostiion = playerObject.GetComponent<Transform>().position;
		playerPostiion.y = 0;
		// How should the boss enemy move (Move patterns?)

		// Force boss to look at player's direction
		Quaternion targetRotation = Quaternion.LookRotation(playerPostiion - transform.position);
		float str = Mathf.Min(turnForce * Time.deltaTime, 1);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
	}

	// Boss attacking
	void handleAttacking()
	{

	}
}
