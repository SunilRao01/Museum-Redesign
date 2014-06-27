using UnityEngine;
using System.Collections;

public class HubworldPlayer : MonoBehaviour 
{
	private string nextMemory;
	public bool enterMemory;

	public float promptAlpha = 0;
	public GUIStyle promptStyle;

	// Mouse
	public Texture2D mouseTexture;
	public float mouseAlpha = 1;

	private GameObject mainCamera;

	void Start () 
	{
		Screen.showCursor = false;
		Screen.lockCursor = false;

		mainCamera = GameObject.Find("Main Camera");
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && enterMemory)
		{
			mainCamera.GetComponent<FadeOut>().nextScene = nextMemory;
			mainCamera.GetComponent<FadeOut>().fade = true;
		}
	}

	void OnGUI()
	{
		// Memory Trigger prompt
		Color inColor = new Color(Color.black.r, Color.black.g, Color.black.b, promptAlpha);
		Color outColor = new Color(Color.white.r, Color.white.g, Color.white.b, promptAlpha);
		
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 250, (Screen.height/2) + 100, 500, 100), "Left Click to activate memory", 
		                             promptStyle, outColor, inColor, 1);

		// Show mouse
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, mouseAlpha);
		
		GUI.DrawTexture(new Rect((Screen.width/2) - 8, (Screen.height/2) - 8, 16, 16), mouseTexture, ScaleMode.ScaleToFit);
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Memory Trigger"))
		{
			enterMemory = true;
			promptAlpha = 1;

			// Check which memory trigger
			// TODO: Enter all instances of memory triggers
			switch (other.gameObject.name)
			{
				case "TED":
					nextMemory = "MemoryHub_Mary";
					break;
			case "Itenerary":
					nextMemory = "IntroductionMemoryHub";
					break;
				default:
					break;

			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Memory Trigger"))
		{
			enterMemory = false;
			promptAlpha = 0;
		}
	}
}
