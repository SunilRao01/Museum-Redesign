using UnityEngine;
using System.Collections;

public class MouseSelection : MonoBehaviour 
{
	public bool lockOn = false;
	private GameObject player;
	private FirstPersonDrifter playerDrifter;
	private LevelInformation levelProgress;

	public bool onObject;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		playerDrifter = player.GetComponent<FirstPersonDrifter>();
		player.GetComponent<PlayerGUI>().wordsAlpha = 1;

		levelProgress = GameObject.Find("Level Information").GetComponent<LevelInformation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// TODO: Figure out a way to hide mouse when needed and while still moving (aka the end pit)
		if (playerDrifter.isMoving && !levelProgress.levelComplete)
		{
			lockOn = false;
			renderer.material.shader = Shader.Find("Diffuse");
			onObject = false;
			player.GetComponent<PlayerGUI>().crosshairAlpha = 1;
			player.GetComponent<PlayerGUI>().wordsAlpha = 1;
		}

		if (!onObject && Input.GetMouseButtonDown(0))
		{
			lockOn = false;
			renderer.material.shader = Shader.Find("Diffuse");
			onObject = false;
		}
		else if (onObject && Input.GetMouseButtonDown(0) && !playerDrifter.isMoving)
		{
			player.GetComponent<PlayerGUI>().crosshairAlpha = 0;
			lockOn = true;
			player.GetComponent<PlayerGUI>().buttonAlpha = 1;
			player.GetComponent<PlayerGUI>().selectedObject = gameObject.name;

			// Remove unnecessary GUI elements
			player.GetComponent<PlayerGUI>().wordsAlpha = 0;
			
			// Disable player looking while choosing an idea
			player.GetComponent<MouseLook>().enabled = false;
			player.transform.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			
			// Should display cursor
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}
	}

	// TODO: Change color of cursor when object is selectable
	void OnMouseOver()
	{
		onObject = true;

		renderer.material.shader = Shader.Find("Custom/OutlinedDiffuse");
	}

	void OnMouseExit()
	{
		onObject = false;

		if (!lockOn)
		{
			renderer.material.shader = Shader.Find("Diffuse");
		}
	}
}
