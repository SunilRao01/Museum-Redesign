﻿using UnityEngine;
using System.Collections;

public class GameTitleMenu : MonoBehaviour 
{
	public GUIStyle titleStyle;
	public GUIStyle instructionStyle;
	public GUIStyle creatorStyle;
	public GUIStyle keyStyle;
	private float titleAlpha = 1;
	private float instructionAlpha = 1;
	private float instructionKeyAlpha = 0.5f;

	// Key booleans
	private bool pressW = false;
	private bool pressA = false;
	private bool pressS = false;
	private bool pressD = false;
	private bool pressLeftClick = false;
	private bool pressRightClick = false;

	// Alpha values
	private float wAlpha = 1;
	private float aAlpha = 1;
	private float sAlpha = 1;
	private float dAlpha = 1;
	private float lcAlpha = 1;
	private float rcAlpha = 1;

	// Title Textures
	public Texture2D keyTexture;
	public Texture2D mouseTexture;

	public Font dearJoeFont;

	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!pressW && Input.GetKeyDown(KeyCode.W))
		{
			pressW = true;
			wAlpha = 0;
		}
		if (!pressA && Input.GetKeyDown(KeyCode.A))
		{
			pressA = true;
			aAlpha= 0;
		}
		if (!pressS && Input.GetKeyDown(KeyCode.S))
		{
			pressS = true;
			sAlpha = 0;
		}
		if (!pressD && Input.GetKeyDown(KeyCode.D))
		{
			pressD = true;
			dAlpha = 0;
		}
		if (!pressLeftClick && Input.GetMouseButtonDown(0))
		{
			pressLeftClick = true;
			lcAlpha = 0;
		}
		if (!pressRightClick && Input.GetMouseButtonDown(1))
		{
			pressRightClick = true;
			rcAlpha = 0;
		}

		if (pressW && pressA && pressS && pressD && pressLeftClick && pressRightClick)
		{
			// Enable game
			GameObject.Find("Player").GetComponent<FirstPersonDrifter>().enabled = true;
			GameObject.Find("Player").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("Main Camera").GetComponent<HeadBob>().enabled = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("Main Camera").GetComponent<CameraZoom>().enabled = true;

			titleAlpha = 0;
			instructionAlpha = 0;
			instructionKeyAlpha = 0;

			pressW = false;
		}
	}

	void OnGUI()
	{
		Color inColor = Color.black;
		inColor.a = titleAlpha;

		Color outColor = Color.white;
		outColor.a = titleAlpha;

		// Game title
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, 0, 100, 100), "The Museum", titleStyle, outColor, inColor, 1);

		// Creator title
		//ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, 0, 100, 100), "A game by Sunil Rao", creatorStyle, outColor, inColor, 1);

		inColor.a = instructionAlpha;
		outColor.a = instructionAlpha;

		// Instructions
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2), (Screen.height/2), 100, 100), "Press the following keys to begin:", instructionStyle, outColor, inColor, 1);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, instructionKeyAlpha);

		//*************
		//  KEY LABELS  
		//*************
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, wAlpha);
		// W Key
		GUI.DrawTexture(new Rect(400, (Screen.height - 200), 50, 50), keyTexture);
		GUI.Label(new Rect(400, (Screen.height - 200 + 5), 50, 50), "W", keyStyle);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, sAlpha);
		// S Key
		GUI.DrawTexture(new Rect(400, (Screen.height - 200) + 60, 50, 50), keyTexture);
		GUI.Label(new Rect(400, (Screen.height - 200 + 5) + 60, 50, 50), "S", keyStyle);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, aAlpha);
		// A Key
		GUI.DrawTexture(new Rect(400 - 60, (Screen.height - 200) + 60, 50, 50), keyTexture);
		GUI.Label(new Rect(400 - 60, (Screen.height - 200 + 5) + 60, 50, 50), "A", keyStyle);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, dAlpha);
		// D Key
		GUI.DrawTexture(new Rect(400 + 60, (Screen.height - 200) + 60, 50, 50), keyTexture);
		GUI.Label(new Rect(400 + 60, (Screen.height - 200 + 5) + 60, 50, 50), "D", keyStyle);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, lcAlpha);
		// Left Click Mouse
		GUI.DrawTexture(new Rect(Screen.width - 400, (Screen.height - 250), 100, 200), mouseTexture);
		GUI.Label(new Rect(Screen.width - 425, (Screen.height - 250), 100, 200), "L", keyStyle);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, rcAlpha);
		// Right Click Mouse
		GUI.DrawTexture(new Rect(Screen.width - 200, (Screen.height - 250), 100, 200), mouseTexture);
		GUI.Label(new Rect(Screen.width - 185, (Screen.height - 250), 100, 200), "R", keyStyle);


	}
}
