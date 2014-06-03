using UnityEngine;
using System.Collections;

public class PlayerBossGUI : MonoBehaviour 
{
	public Texture2D mouseTexture;
	private ArrayList wordsInventory;
	
	private FirstPersonDrifter playerDrifter;

	public float mouseAlpha = 1;
	
	//private float zen;
	private string words;
	
	// Main GUI elements
	//public GUIStyle zenStyle;
	public GUIStyle wordsStyle;
	
	public float wordsAlpha;

	// Boss sections
	public string selectedPower;
	private int currentSelectorPosition = 1;
	public Texture2D wordSelector;

	private Vector2 selectorPosition;


	void Start()
	{
		Screen.lockCursor = true;
		//Screen.showCursor = false;
		
		wordsInventory = GetComponent<Player>().currentWords;
		playerDrifter = GetComponent<FirstPersonDrifter>();
		//zen = GetComponent<Player>().zen;
		words = GetComponent<Player>().words;
	}
	
	void Update() 
	{
		selectedPower = wordsInventory[currentSelectorPosition-1].ToString();

		//zen = GetComponent<Player>().zen;
		words = GetComponent<Player>().words;
		
		if (playerDrifter.isMoving)
		{
			Screen.lockCursor = true;
			Screen.showCursor = false;
			
			GetComponent<MouseLook>().enabled = true;
			transform.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
		}
		
		if (Input.GetMouseButtonDown(0))
		{
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
		}

		handleInput();
	}

	void handleInput()
	{
		// Handle player changing abilities
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Color newColor = GetComponent<PlayerShooting>().aimingBlock.renderer.material.color;
			newColor.a = 0.5f;
			GetComponent<PlayerShooting>().aimingBlock.renderer.material.color = newColor;


			currentSelectorPosition = 1;

			//selectedPower = 
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Color newColor = GetComponent<PlayerShooting>().aimingBlock.renderer.material.color;
			newColor.a = 0;
			GetComponent<PlayerShooting>().aimingBlock.renderer.material.color = newColor;

			currentSelectorPosition = 2;

		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Color newColor = GetComponent<PlayerShooting>().aimingBlock.renderer.material.color;
			newColor.a = 0;
			GetComponent<PlayerShooting>().aimingBlock.renderer.material.color = newColor;


			currentSelectorPosition = 3;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			Color newColor = GetComponent<PlayerShooting>().aimingBlock.renderer.material.color;
			newColor.a = 0;
			GetComponent<PlayerShooting>().aimingBlock.renderer.material.color = newColor;


			currentSelectorPosition = 4;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			Color newColor = GetComponent<PlayerShooting>().aimingBlock.renderer.material.color;
			newColor.a = 0;
			GetComponent<PlayerShooting>().aimingBlock.renderer.material.color = newColor;


			currentSelectorPosition = 5;
		}
	}
	
	void OnGUI()
	{
		// Show zen count
		//ShadowAndOutline.DrawOutline(new Rect(0, 60, Screen.width, 80), zen.ToString(), zenStyle, Color.white, Color.black, 3);
		
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


		string[] delims = new string[1];
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

		selectorPosition.x = (Screen.width/2) - output.Length * 4.8f;
		selectorPosition.x += (120 * (currentSelectorPosition-1));
		selectorPosition.y = Screen.height - 80;
		// Display word/power selector
		GUI.DrawTexture(new Rect(selectorPosition.x, selectorPosition.y, 100, 50), wordSelector);


		// Display mouse
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, mouseAlpha);
		GUI.DrawTexture(new Rect((Screen.width/2) - 8, (Screen.height/2) - 8, 16, 16), mouseTexture, ScaleMode.ScaleToFit);
	}
}
