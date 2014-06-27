using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	
	// FadeInOut
	public Texture2D fadeTexture;

	public bool fade = false;

	private float alpha = 1;
	public float alphaSpeed;

	public bool deleteFade;

	void Start()
	{
		if (deleteFade)
		{
			Destroy (this);
		}
	}

	void Update()
	{
		if (fade && alpha > 0)
		{
			alpha -= alphaSpeed;
		}
		else if (alpha <= 0)
		{



			enabled = false;
		}
	}

	void OnGUI()
	{
		GUI.depth = 1;
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
		
	}
}
