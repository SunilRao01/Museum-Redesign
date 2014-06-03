using UnityEngine;
using System.Collections;

public class HubworldPlayer : MonoBehaviour 
{
	private string nextMemory;
	public bool enterMemory;

	public float promptAlpha = 0;
	public GUIStyle promptStyle;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && enterMemory)
		{
			Application.LoadLevel(nextMemory);
		}
	}

	void OnGUI()
	{
		Color inColor = new Color(Color.black.r, Color.black.g, Color.black.b, promptAlpha);
		Color outColor = new Color(Color.white.r, Color.white.g, Color.white.b, promptAlpha);
		
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 250, (Screen.height/2) + 100, 500, 100), "Press E to activate memory", 
		                             promptStyle, outColor, inColor, 1);
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
