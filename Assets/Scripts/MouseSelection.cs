using UnityEngine;
using System.Collections;

public class MouseSelection : MonoBehaviour 
{
	public bool lockOn = false;
	private GameObject player;
	private FirstPersonDrifter playerDrifter;

	public bool onObject;
	private Texture2D mouseCursor;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		playerDrifter = player.GetComponent<FirstPersonDrifter>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		mouseCursor = GameObject.Find("Player").GetComponent<PlayerGUI>().mouseTexture;

		if (playerDrifter.isMoving)
		{
			lockOn = false;
			renderer.material.shader = Shader.Find("Diffuse");
			onObject = false;
			player.GetComponent<PlayerGUI>().mouseAlpha = 1;
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
			player.GetComponent<PlayerGUI>().mouseAlpha = 0;
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
			Debug.Log("Process player and " + gameObject.name + " interaction.");
		}
	}

	// TODO: Change color of cursor when object is selectable
	void OnMouseOver()
	{
		Debug.Log("Hovering over " + gameObject.name);
		onObject = true;

		renderer.material.shader = Shader.Find("Custom/OutlinedDiffuse");

		// Change cursor color
		Color[] pixes = mouseCursor.GetPixels();
		
		for (int i = 0; i < pixes.Length; i++)
		{
			pixes[i] = Color.grey;
		}
		
		mouseCursor.SetPixels(pixes);
	}

	void OnMouseExit()
	{
		onObject = false;

		if (!lockOn)
		{
			renderer.material.shader = Shader.Find("Diffuse");
		}

		// Revert cursor color
		Color[] pixes = mouseCursor.GetPixels();

		for (int i = 0; i < pixes.Length; i++)
		{
			pixes[i] = Color.white;
		}

		mouseCursor.SetPixels(pixes);
	}
}
