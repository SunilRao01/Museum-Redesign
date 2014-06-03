using UnityEngine;
using System.Collections;

public class MemoryDialogue : MonoBehaviour 
{
	public float dialogueAlpha = 1;
	public GUIStyle dialogueStyle;
	public float dialogueSize;
	public Color dialogueColor;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void startDialogue(string inputDialogue)
	{

	}

	void OnGUI()
	{
		Color outColor = Color.white;
		Color inColor = dialogueColor;

		outColor.a = dialogueAlpha;
		inColor.a = dialogueAlpha;

		ShadowAndOutline.DrawOutline(new Rect(0, Screen.height - 70, Screen.width - 16, 50), "Sample dialogue", dialogueStyle, outColor, inColor, dialogueSize);
	}
}
