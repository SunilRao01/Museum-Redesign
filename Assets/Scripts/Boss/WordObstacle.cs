using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class WordObstacle : MonoBehaviour 
{
	public bool canChallenge;

	private float playerInputAlpha;

	private string playerInput = "";

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (canChallenge && Input.GetKeyDown(KeyCode.LeftShift))
		{
			// Show player input option
			playerInputAlpha = 1;


		}
	}

	void OnGUI()
	{
		// TODO: Show player input dialogue box

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, playerInputAlpha);
		GUI.SetNextControlName("player input");
		playerInput = GUI.TextField(new Rect((Screen.width/2) - 30, (Screen.height/2) + 220, 140, 30), playerInput);
		playerInput = Regex.Replace(playerInput, @"[^a-z]", "");

		// Handle player input
		Event e = Event.current;
		Player playerScript = GameObject.Find("Player").GetComponent<Player>();

		// Allow player to type when text field becomes visible
		if (playerInputAlpha == 1)
		{
			GUI.FocusControl("player input");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			canChallenge = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			canChallenge = false;
			//playerInputAlpha = 0;
		}
	}
}
