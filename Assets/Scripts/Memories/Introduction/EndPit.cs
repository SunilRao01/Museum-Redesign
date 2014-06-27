using UnityEngine;
using System.Collections;

public class EndPit : MonoBehaviour 
{
	private float progressAlpha = 1;
	public GUIStyle titleStyle;

	void Start () 
	{
	
	}
	
	void Update () 
	{

	}

	void OnGUI()
	{
		Color outColor = Color.white;
		Color inColor = Color.black;

		outColor.a = progressAlpha;
		inColor.a = progressAlpha;

		//ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, (Screen.height/2) - 50, 100, 100), "Memory Complete", titleStyle, outColor, inColor, 1);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			progressAlpha = 1;
			//audio.Play();

			// TODO: Reduce player's gravity
			other.GetComponent<FirstPersonDrifter>().gravity = 0.5f;
			GetComponent<FadeLabel>().enabled = true;

			// TODO: Possible add cool particle effect, child'd to camera/player
			// (Local transformation/rotation)

			// TODO: Display game title
		}
	}
}
