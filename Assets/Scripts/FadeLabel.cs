using UnityEngine;
using System.Collections;

public class FadeLabel : MonoBehaviour 
{
	public int introDelay;

	public GUIStyle dayStyle;

	// Logo display
	private float fadeAlpha2;
	public float fadeInterval;


	public string dayString;

	private GameObject cameraObject;

	// Use this for initialization
	void Start () 
	{
		cameraObject = GameObject.Find("Main Camera");

		fadeAlpha2 = 0;
		StartCoroutine(fade());
	}

	void Update()
	{
		Debug.Log("Fade alpha: " + fadeAlpha2.ToString());
	}

	IEnumerator fade()
	{
		yield return new WaitForSeconds(introDelay);

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

		cameraObject.GetComponent<FadeIn>().fade = true;
		//Destroy(this);
	}
	
	void OnGUI()
	{
		GUI.depth = 0;
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, fadeAlpha2);

		Color inColor = new Color(Color.black.r, Color.black.g, Color.black.b, fadeAlpha2);
		Color outColor = new Color(Color.white.r, Color.white.g, Color.white.b, fadeAlpha2);

		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, (Screen.height/2) - 50, 100, 100), dayString, 
		                             dayStyle, outColor, inColor, 1);
		
	}
}
