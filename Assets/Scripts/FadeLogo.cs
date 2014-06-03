using UnityEngine;
using System.Collections;

public class FadeLogo : MonoBehaviour 
{
	public int introDelay;

	public int day;
	public GUIStyle dayStyle;

	// Logo display
	public Texture2D logoImage;
	private float fadeAlpha;
	private float fadeAlpha2;
	public float fadeInterval;

	public int logoSizeX;
	public int logoSizeY;

	private string dayString;

	// Use this for initialization
	void Start () 
	{
		fadeAlpha = 0;
		fadeAlpha2 = 0;
		StartCoroutine(fade());
	}
	
	// Update is called once per frame
	void Update () 
	{
		dayString = "Day " + day.ToString();
	}
	IEnumerator fade()
	{
		yield return new WaitForSeconds(introDelay);

		while (fadeAlpha < 1)
		{
			fadeAlpha += 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
		
		yield return new WaitForSeconds(fadeInterval);
		
		while (fadeAlpha > 0)
		{
			fadeAlpha -= 0.01f;
			yield return new WaitForSeconds(0.01f);
		}

		yield return new WaitForSeconds(0.5f);

		while (fadeAlpha2 < 1)
		{
			fadeAlpha2 += 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
		
		yield return new WaitForSeconds(fadeInterval);
		
		while (fadeAlpha2 > 0)
		{
			fadeAlpha2 -= 0.01f;
			yield return new WaitForSeconds(0.01f);
		}

		//Destroy(this);
	}
	
	void OnGUI()
	{



		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, fadeAlpha);
		GUI.DrawTexture(new Rect((Screen.width/2) - (logoSizeX/2), (Screen.height/2) - (logoSizeY/2) - (Screen.height/4), logoSizeX, logoSizeY), logoImage);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, fadeAlpha2);

		Color inColor = new Color(Color.black.r, Color.black.g, Color.black.b, fadeAlpha2);
		Color outColor = new Color(Color.white.r, Color.white.g, Color.white.b, fadeAlpha2);
		


		if (day != 0)
		{
			//GUI.Label(new Rect((Screen.width/2), (Screen.height/2), 100, 100), "Day 1", dayStyle);
			ShadowAndOutline.DrawOutline(new Rect((Screen.width/2), (Screen.height/2), 100, 100), dayString, 
			                             dayStyle, outColor, inColor, 1);
		}
	}
}
