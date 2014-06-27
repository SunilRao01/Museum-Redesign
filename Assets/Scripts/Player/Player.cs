using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public ArrayList currentWords;
	public string words;
	public GUIText zenGUI;

	public bool lockMovement;	

	public float zen = 0;
	
	public bool hasKey = false;

	public bool debug;

	public int bossHealth;
	public int maxBossHealth;

	// Game Menu
	private float gameMenuAlpha;
	public GUIStyle tabStyle;
	public GUIStyle progressStyle;
	private float progressionAlpha;
	public Font memoryGridFont;
	private float memoryGridAlpha;
	private float xOffset = 158;
	private float yOffset = 167;

	private float exitAlpha;
	public GUIStyle titleStyle;
	public GUIStyle memoryLabelStyle;
	public GUIStyle progressionPercentageStyle;
	public GUIStyle progressionNameStyle;
	public GUIStyle progressionPaintingStyle;
	public GUIStyle progressionObstacleStyle;

	void Awake () 
	{
		currentWords = new ArrayList();
	}

	void Start()
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;

		addWord("Blocks");
		addWord("Rage");
		addWord("Pollution");
	}
	
	void OnGUI()
	{
		// EXIT MENU
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, exitAlpha);
		GUIStyle buttonStyle = new GUIStyle("button");
		buttonStyle.font = memoryGridFont;
		buttonStyle.fontSize = 16;
		
		// Exit buttons
		if (GUI.Button(new Rect((Screen.width/2) - 60, (Screen.height/2) - 30 - 100, 120, 60), "Continue", buttonStyle))
		{
			exitAlpha = 0;

			// Enable game
			GameObject.Find("Player").GetComponent<FirstPersonDrifter>().enabled = true;
			GameObject.Find("Player").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("Main Camera").GetComponent<HeadBob>().enabled = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("Main Camera").GetComponent<CameraZoom>().enabled = true;
			
			// Hide and lock mouse
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}
		if (GUI.Button(new Rect((Screen.width/2) - 60, (Screen.height/2) - 30, 120, 60), "Options", buttonStyle))
		{
			// TODO: Options menu
		}
		if (GUI.Button(new Rect((Screen.width/2) - 60, (Screen.height/2) - 30 + 100, 120, 60), "Exit", buttonStyle))
		{
			Application.Quit();

		
		}

		// TITLE
		Color inColor = Color.black;
		inColor.a = exitAlpha;
		
		Color outColor = Color.white;
		outColor.a = exitAlpha;

		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, 0, 100, 400), "The Museum", titleStyle, outColor, inColor, 2);


		// GAME MENU
		inColor = Color.black;
		outColor = Color.white;
		inColor.a = gameMenuAlpha;
		outColor.a = gameMenuAlpha;
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, gameMenuAlpha);

		// Tabs
		if (GUI.Button(new Rect((Screen.width/2) - 400, (Screen.height/2) - 200, 160, 50), GUIContent.none))
		{
			progressionAlpha = 0;
			memoryGridAlpha = 1;
		}
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 400, (Screen.height/2) - 200, 160, 50), "Memories", tabStyle, outColor, inColor, 1.5f);

		if (GUI.Button(new Rect((Screen.width/2) - 400, (Screen.height/2) - 140, 160, 50), GUIContent.none))
		{
			memoryGridAlpha = 0;
			progressionAlpha = 1;
		}
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 400, (Screen.height/2) - 140, 160, 50), "Progress", tabStyle, outColor, inColor, 1.5f);

		// Box
		GUI.Box(new Rect((Screen.width/2) - 200, (Screen.height/2) - 200, 512, 512), GUIContent.none);
		GUIStyle gridStyle = new GUIStyle(GUI.skin.button);
		gridStyle.font = memoryGridFont;

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, memoryGridAlpha);
		inColor.a = memoryGridAlpha;
		outColor.a = memoryGridAlpha;

		// Memory Grid
		for (int i = 0; i < 3; i++)
		{
			// Button (w/ Item image)
			GUI.Button(new Rect((Screen.width/2) - 150 + (xOffset * i), (Screen.height/2) - 150, 100, 100), GUIContent.none, gridStyle);

			// Label
			ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 150 + (xOffset * i), (Screen.height/2) - 150, 100, 100), "Label", memoryLabelStyle, outColor, inColor, 1);

			for (int j = 1; j < 3; j++)
			{
				GUI.Button(new Rect((Screen.width/2) - 150 + (xOffset * i), (Screen.height/2) - 150 + (xOffset * j), 100, 100), GUIContent.none, gridStyle);
				ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 150 + (xOffset * i), (Screen.height/2) - 150 + (xOffset * j), 100, 100), "Label", memoryLabelStyle, outColor, inColor, 1);
			}
		}

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, progressionAlpha);
		inColor.a = progressionAlpha;
		outColor.a = progressionAlpha;

		// Progression Grid
		for (int k = 0; k < 3; k++)
		{
			// Box
			GUI.Box(new Rect((Screen.width/2) - 180, (Screen.height/2) - 180 + (yOffset * k), 470, 128), GUIContent.none);

			// Percentage Label
			ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 170, (Screen.height/2) - 170 + (yOffset * k), 100, 100), "0%", progressionPercentageStyle, outColor, inColor, 1);

			// Memory Label
			ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) + 60, (Screen.height/2) - 190 + (yOffset * k), 100, 100), "[Memory Name]", progressionNameStyle, outColor, inColor, 1);

			// Painting Progression Label
			ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) + 60, (Screen.height/2) - 200 + (yOffset * k), 100, 100), "X/X Paintings", progressionPaintingStyle, outColor, inColor, 1);

			// Obstacle Progression Label
			ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) + 60, (Screen.height/2) - 210 + (yOffset * k), 100, 100), "X/X Obstacles", progressionObstacleStyle, outColor, inColor, 1);
		}

	}

	void Update()
	{
		handleInput();
	}

	void handleInput()
	{
		// Exit Menu
		if (Input.GetKeyDown(KeyCode.Escape) && exitAlpha == 0)
		{
			exitAlpha = 1;

			// Enable game
			GameObject.Find("Player").GetComponent<FirstPersonDrifter>().enabled = false;
			GameObject.Find("Player").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("Main Camera").GetComponent<HeadBob>().enabled = false;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("Main Camera").GetComponent<CameraZoom>().enabled = false;
			
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}

		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (gameMenuAlpha == 0)
			{
				gameMenuAlpha = 1;
				memoryGridAlpha = 1;

				Screen.lockCursor = false;
				Screen.showCursor = true;

				GetComponent<FirstPersonDrifter>().lockMovement = true;
				GetComponent<MouseLook>().enabled = false;
				transform.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
				transform.Find("Main Camera").GetComponent<LockMouse>().enabled = false;

				if (Application.loadedLevelName == "HouseHub")
				{
					GetComponent<HubworldPlayer>().mouseAlpha = 0;
				}
			}
			else
			{
				gameMenuAlpha = 0;
				memoryGridAlpha = 0;
				progressionAlpha = 0;

				Screen.lockCursor = true;
				Screen.showCursor = false;

				GetComponent<FirstPersonDrifter>().lockMovement = false;
				GetComponent<MouseLook>().enabled = true;
				transform.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
				transform.Find("Main Camera").GetComponent<LockMouse>().enabled = true;

				if (Application.loadedLevelName == "HouseHub")
				{
					GetComponent<HubworldPlayer>().mouseAlpha = 1;
				}
			}
		}
	}

	void updateWords()
	{
		words = "";

		for (int i = 0; i < currentWords.Count; i++)
		{
			words += currentWords[i] + System.Environment.NewLine + System.Environment.NewLine;
		}
	}

	// Show effect when adding zen
	public void addZen(ref int currentZen)
	{
		currentZen++;
	}

	public void zenUp()
	{
		zen++;
	}

	// TODO: Show effects when adding/remove words
	public void addWord(string word)
	{
		currentWords.Add(word);
		updateWords();
	}

	public void removeWord(int position)
	{
		currentWords.RemoveAt(position);
		updateWords();
	}
}
