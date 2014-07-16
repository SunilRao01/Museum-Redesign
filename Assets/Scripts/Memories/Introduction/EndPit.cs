using UnityEngine;
using System.Collections;

public class EndPit : MonoBehaviour 
{
	public int introDelay;
	
	public GUIStyle dayStyle;
	
	// Alpha variables
	private float titleFadeAlpha;
	private float paintingsFadeAlpha;
	private float obstaclesFadeAlpha;


	public float fadeInterval;

	private GameObject cameraObject;

	private LevelInformation levelProgress;

	// Use this for initialization
	void Start () 
	{
		cameraObject = GameObject.Find("Main Camera");


		levelProgress = GameObject.Find("Level Information").GetComponent<LevelInformation>();
	}
	
	void Update()
	{

	}
	
	IEnumerator fade()
	{
		yield return new WaitForSeconds(introDelay);
		
		// Fade title in
		while (titleFadeAlpha < 1)
		{
			titleFadeAlpha += 0.02f;
			yield return new WaitForSeconds(0.02f);
		}
		
		yield return new WaitForSeconds(fadeInterval);

		// Fade title out
		while (titleFadeAlpha > 0)
		{
			titleFadeAlpha -= 0.02f;
			yield return new WaitForSeconds(0.02f);
		}



		yield return new WaitForSeconds(fadeInterval);

		// Fade painting progression in
		while (paintingsFadeAlpha < 1)
		{
			paintingsFadeAlpha += 0.02f;
			yield return new WaitForSeconds(0.02f);
		}

		yield return new WaitForSeconds(fadeInterval);

		// Fade paintings progression out
		while (paintingsFadeAlpha > 0)
		{
			paintingsFadeAlpha -= 0.02f;
			yield return new WaitForSeconds(0.02f);
		}



		yield return new WaitForSeconds(fadeInterval);
		
		// Fade painting progression in
		while (obstaclesFadeAlpha < 1)
		{
			obstaclesFadeAlpha += 0.02f;
			yield return new WaitForSeconds(0.02f);
		}
		
		yield return new WaitForSeconds(fadeInterval);
		
		// Fade paintings progression out
		while (obstaclesFadeAlpha > 0)
		{
			obstaclesFadeAlpha -= 0.02f;
			yield return new WaitForSeconds(0.02f);
		}

		Debug.Log("Should fade!");
		cameraObject.GetComponent<FadeOut>().fade = true;
	}
	
	void OnGUI()
	{
		// Title
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, titleFadeAlpha);
		
		Color inColor = new Color(Color.black.r, Color.black.g, Color.black.b, titleFadeAlpha);
		Color outColor = new Color(Color.white.r, Color.white.g, Color.white.b, titleFadeAlpha);
		
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, (Screen.height/2) - 50, 100, 100), "Memory Complete", 
		                             dayStyle, outColor, inColor, 1);


		// Painting Progression
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, paintingsFadeAlpha);
		
		inColor = new Color(Color.black.r, Color.black.g, Color.black.b, paintingsFadeAlpha);
		outColor = new Color(Color.white.r, Color.white.g, Color.white.b, paintingsFadeAlpha);

		string label1 = "Paintings: " + levelProgress.currentPaintings.ToString() + "/" + levelProgress.totalPaintings.ToString();
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, (Screen.height/2) - 50, 100, 100), 
		                             label1, dayStyle, outColor, inColor, 1);


		// Obstacle Progression
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, obstaclesFadeAlpha);
		
		inColor = new Color(Color.black.r, Color.black.g, Color.black.b, obstaclesFadeAlpha);
		outColor = new Color(Color.white.r, Color.white.g, Color.white.b, obstaclesFadeAlpha);
		
		string label2 = "Conflicts: " + levelProgress.currentObstacles.ToString() + "/" + levelProgress.totalObstacles.ToString();
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2) - 50, (Screen.height/2) - 50, 100, 100), 
		                             label2, dayStyle, outColor, inColor, 1);
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			other.GetComponent<FirstPersonDrifter>().gravity = 0;
			other.GetComponent<PlayerGUI>().crosshairAlpha = 0;
			levelProgress.levelComplete = true;

			// Update saved level information
			if (Application.loadedLevelName == "IntroductionMemory")
			{
				PlayerPrefs.SetInt("Memory_Introduction_Paintings", levelProgress.currentPaintings);
				PlayerPrefs.SetInt("Memory_Introduction_TotalPaintings", levelProgress.totalPaintings);
				PlayerPrefs.SetInt("Memory_Introduction_Obstacles", levelProgress.currentObstacles);
				PlayerPrefs.SetInt("Memory_Introduction_TotalObstacles", levelProgress.totalObstacles);

				int totalPercentage = Mathf.RoundToInt( ((levelProgress.currentObstacles + levelProgress.currentPaintings) / (levelProgress.totalPaintings + levelProgress.totalObstacles)) * 100);
				PlayerPrefs.SetInt("Memory_Introduction_PercentageComplete", totalPercentage);

				// Update global game information (for game menu)
				PlayerPrefs.SetString("Game_TotalProgress", "1000000");

				PlayerPrefs.SetInt("LevelsComplete", 1);
			}

			StartCoroutine(fade());
		}
	}
}
