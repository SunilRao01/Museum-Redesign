using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour 
{
	public Texture2D mouseTexture;
	private ArrayList wordsInventory;

	// Grid Selection
	private float yInterval = 80;

	public float buttonAlpha;
	public string selectedObject;

	private FirstPersonDrifter playerDrifter;

	private float xButtonPosition = 146;
	private float yButtonPosition = 873.6f;

	public Font dearJoeFont;
	private int buttonFontSize = 30;

	private GUIStyle buttonStyle;
	public GUIText currentWords;

	public float mouseAlpha = 1;

	private float zen;
	private string words;

	// Main GUI elements
	public GUIStyle zenStyle;
	public GUIStyle wordsStyle;

	public float wordsAlpha;
	private float xOffset = 420;

	// Boss sections
	public string selectedPower;



	void Start () 
	{
		Screen.lockCursor = true;
		//Screen.showCursor = false;

		wordsInventory = GetComponent<Player>().currentWords;
		playerDrifter = GetComponent<FirstPersonDrifter>();
		zen = GetComponent<Player>().zen;
		words = GetComponent<Player>().words;

	}
	
	void Update () 
	{
		zen = GetComponent<Player>().zen;
		words = GetComponent<Player>().words;

		if (playerDrifter.isMoving)
		{
			buttonAlpha = 0;
			Screen.lockCursor = true;
			Screen.showCursor = false;

			GetComponent<MouseLook>().enabled = true;
			transform.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		}

		if (Input.GetMouseButtonDown(0) && buttonAlpha == 0)
		{
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}

		// Handle start menu
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}

		if (buttonAlpha == 0)
		{
			Color newColor = Color.black;
			newColor.a = 1;

			currentWords.color = newColor;
		}
		else
		{
			Color newColor = Color.black;
			newColor.a = 0;
			
			currentWords.color = newColor;
		}
	}

	void OnGUI()
	{
		// Show zen count (If applicable)
		if (Application.loadedLevelName != "HouseHub")
		{
			ShadowAndOutline.DrawOutline(new Rect(0, 60, Screen.width, 80), zen.ToString(), zenStyle, Color.white, Color.black, 3);
		}

		// Show words in inventory
		Color tempInColor = Color.black;
		Color tempOutColor = Color.white;

		if (wordsAlpha == 0)
		{
			tempInColor.a = 0;
			tempOutColor.a = 0;
		}
		else
		{
			tempInColor.a = 1;
			tempOutColor.a = 1;
		}


		// Check if you're in the debug 'Sandbox' level
		if (Application.loadedLevelName == "Sandbox")
		{
			// TODO: Set up words when in first-person-exploration mode
			string[] delims = new string[1];
			//delims[0] = " ";
			delims[0] = "\n";
			string[] newWords = words.Split(delims, System.StringSplitOptions.RemoveEmptyEntries);
			string output = string.Join("   ", newWords);

			string[] numKeys = new string[newWords.Length];
			for (int i = 0; i < wordsInventory.Count; i++)
			{
				numKeys[i] = (i+1).ToString();
			}
			string numOutput = string.Join("            ", numKeys);

			// Display corresponding num keys to switch active words
			ShadowAndOutline.DrawOutline(new Rect(0, Screen.height - 250, Screen.width, 300), numOutput.ToString(), wordsStyle, tempOutColor, tempInColor, 1);

			// Display words 
			ShadowAndOutline.DrawOutline(new Rect(0, Screen.height - 200, Screen.width, 300), output.ToString(), wordsStyle, tempOutColor, tempInColor, 1);
		}
		else
		{
			ShadowAndOutline.DrawOutline(new Rect((Screen.width) - xOffset, 50, 400, Screen.height), words.ToString(), wordsStyle, tempOutColor, tempInColor, 1);
		}



		// Show mouse
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, mouseAlpha);
		
		GUI.DrawTexture(new Rect((Screen.width/2) - 8, (Screen.height/2) - 8, 16, 16), mouseTexture, ScaleMode.ScaleToFit);


		//***********************
		// SHOW WORD BUTTON GRID
		//***********************

		// Make the button word grid visible FOR ALL TO SEE AND PONDER ZEEHAHAHAHAHA
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, buttonAlpha);

		buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.font = dearJoeFont;
		buttonStyle.fontSize = buttonFontSize;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonStyle.wordWrap = true;

		Vector2 tempBlock = new Vector2(0, 0);

		// Display grid of possible selections
		for (int i = 0; i < wordsInventory.Count; i++)
		{


			if (i > 0)
			{
				//tempBlock.x = Screen.width - 180;// (i + (Screen.width/4));
				tempBlock.y += yInterval;// (i + (Screen.height/4));
			}
			else
			{
				tempBlock.x = Screen.width - xButtonPosition;
				tempBlock.y = Screen.height - yButtonPosition;
			}
			
			if (GUI.Button(new Rect(tempBlock.x, tempBlock.y, 120, 60), wordsInventory[i].ToString(), buttonStyle))
			{

				// TODO: Process button selection
				string sceneName = Application.loadedLevelName;
				string tempWordInv = wordsInventory[i].ToString();

				//**********************
				// HANDLE MATCH PAIRING
				//**********************

				if (sceneName == "OfficeMemory")
				{
					// Physical object solutions
					if (selectedObject == "Water Bottle")
					{
						if (tempWordInv == "Water")
						{

							GetComponent<Player>().removeWord(i);
							GetComponent<Player>().zenUp();
						}
					}

					// Character solutions
					else if (selectedObject == "SadPhil")
					{
						if (tempWordInv == "Rage")
						{

							GetComponent<Player>().removeWord(i);
							GetComponent<Player>().zenUp();

							// Make player move to designated area
							GetComponent<MaryOfficeInteractions>().startInteraction(selectedObject);
						}
					}
					else if (selectedObject == "PlantManager")
					{
						if (tempWordInv == "Pollution")
						{
							GetComponent<Player>().removeWord(i);
							GetComponent<Player>().zenUp();

							// Make player move to designated area
							GetComponent<MaryOfficeInteractions>().startInteraction(selectedObject);
						}
					}
				}

			}
		}
	}
}
