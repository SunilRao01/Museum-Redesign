using UnityEngine;
using System.Collections;
using System.Linq;

public class Painting : MonoBehaviour 
{
	// Player
	private Player player;
	private FirstPersonDrifter playerMovement;
	private Camera mainCamera;

	// Alpha
	private float promptAlpha;
		
	// Zen
	public int maxZen;
	private int currentZen = 0;
	
	// Word Processing
	public string paintingIdea;
	public string [] validWords;
	private ArrayList processedWords;
	private bool finished;
	
	// GUI Styles
	private string promptText;
	public GUIStyle promptStyle;
	public GUIStyle zenStyle;
	
	// Painting/Text
	public Material painting;
	
	// Text Input
	public TextMesh textInput;
	public Material textMaterial;
	private bool canType;
	private bool hasEntered;
	private bool allComplete;

	// Painting Visual Progression
	public float particleBlock;

	// Level Information
	private LevelInformation levelProgress;
	
	void Start ()
	{
		player = GameObject.Find("Player").GetComponent<Player>();
		playerMovement = GameObject.Find("Player").GetComponent<FirstPersonDrifter>();
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

		allComplete = false;
		renderer.material = painting;
		//renderer.material.color = Color.grey;
		//textMaterial.color = new Color(0.8f, 0.8f, 0.8f, 1);
		
		processedWords = new ArrayList();
		finished = false;
		canType = false;

		promptText = "Press spacebar to interact";
		hasEntered = false;	

		// Particle effects
		// MAX: 2
		particleBlock = 2.0f / maxZen;

		levelProgress = GameObject.Find("Level Information").GetComponent<LevelInformation>();
		textMaterial.color = new Color(textMaterial.color.r, textMaterial.color.g, textMaterial.color.b, 0);
	}
	
	void Update ()
	{		
		// Puts all player input into 3d text
		foreach (char c in Input.inputString)
		{
			if (canType)
			{
				// Valid keys for input
				
				// Backspace key
				if (c == "\b"[0]) 
				{
					if (textInput.text.Length != 0)
					{
						textInput.text = textInput.text.Substring(0, textInput.text.Length - 1);
					}
				}
				// Return key
				else if (c == "\n"[0] || c == "\r"[0])
				{
					checkPhrase(textInput.text);
					textInput.text = "";
				}
				// Every other key is valid
				else
				{
					textInput.text += c;
				}
			}
		}
		
		// Painting is finished when the word count == valid words count (Needs to be changed)
		if (currentZen >= maxZen)
		{
			finished = true;


		}
		
		// Checks if painting is finished
		if (finished)
		{
			renderer.material.color = new Color(0.1f, 0.1f, 0.1f, 1);
			if (!allComplete)
			{
				promptText = "Painting complete press Shift to exit";
				promptStyle.normal.textColor = Color.white;
				player.addWord(paintingIdea);

				levelProgress.currentPaintings++;

				iTween.ScaleTo(transform.GetChild(1).gameObject, iTween.Hash("scale", new Vector3(0.23f, 0.05f, 1.14f), "time", 1, "easetype", iTween.EaseType.easeOutElastic));
				StartCoroutine(fadePlatformOut());
			}

			allComplete = true;
			
			canType = false;
		}
		else
		{
			renderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1);
		}
		
		handleInput();
	}
	
	void handleInput()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (hasEntered)
			{				
				if (!finished)
				{
					if (canType)
					{
						canType = false;
					}
					else if (!canType)
					{
						promptText = "Press shift to exit";
						canType = true;

						// Normal size scale: (0.72, 0.16, 3.59)
						// Small size scale: (0.23, 0.05, 1.14)
						iTween.ScaleTo(transform.GetChild(1).gameObject, iTween.Hash("scale", new Vector3(0.72f, 0.16f, 3.59f), "time", 1, "easetype", iTween.EaseType.easeOutElastic));
						StartCoroutine(fadePlatformIn());
					}

					if (playerMovement.lockMovement)
					{
						playerMovement.lockMovement = false;
						mainCamera.GetComponent<HeadBob>().enableBob = true;
						promptText = "Press shift to interpret";
						textInput.text = "";
						player.GetComponent<PlayerGUI>().crosshairAlpha = 1;

						iTween.ScaleTo(transform.GetChild(1).gameObject, iTween.Hash("scale", new Vector3(0.23f, 0.05f, 1.14f), "time", 1, "easetype", iTween.EaseType.easeOutElastic));
						StartCoroutine(fadePlatformOut());
					}
					else
					{
						playerMovement.lockMovement = true;
						mainCamera.GetComponent<HeadBob>().enableBob = false;
						player.GetComponent<PlayerGUI>().crosshairAlpha = 0;
					}
					
					promptAlpha = 0;
				}

				else
				{
					playerMovement.lockMovement = false;
					mainCamera.GetComponent<HeadBob>().enableBob = true;
					promptAlpha = 0;
					promptText = "";


				}
					


				

			}
		}

		if (mainCamera.GetComponent<CameraZoom>().zooming && hasEntered)
		{
			promptAlpha = 0;
		}
		else if (!mainCamera.GetComponent<CameraZoom>().zooming && hasEntered)
		{
			promptAlpha = 1;
		}
	}
	
	IEnumerator fadePlatformIn()
	{
		Color newColor = Color.white;
		newColor.a = 0;
		while (newColor.a < 1)
		{
			newColor.a += 0.1f;
			textMaterial.color = newColor;
			yield return new WaitForSeconds(0.01f);
		}
	}

	IEnumerator fadePlatformOut()
	{
		Color newColor = Color.white;
		newColor.a = 1;
		while (newColor.a > 0)
		{
			newColor.a -= 0.1f;
			textMaterial.color = newColor;
			yield return new WaitForSeconds(0.01f);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !finished)
		{
			promptAlpha = 1;
			promptText = "Press shift to interpret";
			hasEntered = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (!finished)
			{
				promptAlpha = 0;
				hasEntered = false;
			}
			else if (finished)
			{
				promptText = "";
				promptAlpha = 0;
				hasEntered = false;
			}
		}
	}
	
	void OnGUI()
	{		
		Color inColor = new Color(Color.black.r, Color.black.g, Color.black.b, promptAlpha);
		Color outColor = new Color(Color.white.r, Color.white.g, Color.white.b, promptAlpha);
		
		ShadowAndOutline.DrawOutline(new Rect((Screen.width/2), (Screen.height/2), 500, 100), promptText, 
			promptStyle, outColor, inColor, 1);
		
		
		//string zenText = currentZen + "/" + maxZen;
		//ShadowAndOutline.DrawOutline(new Rect((Screen.width/2), (Screen.height/10), 500, 100), zenText, zenStyle, outColor, inColor, 1);

	}
	
	// Checks if inputted word is valid
	void checkPhrase(string input)
	{
		string text = input;
		
		// Checks if VALID word
		for (int i = 0; i < validWords.Length; i++)
		{
			// If input is a valid interpretation
			if (text == validWords[i] || (text[text.Length-1] == 's' && text.Substring(0, text.Length-1) == validWords[i]))
			{
				processedWords.Add(validWords[i]);
				player.addZen(ref currentZen);
				
				// Remove element from array
				validWords = validWords.Where(w => w != validWords[i]).ToArray();


				//GetComponentInChildren<ParticleEmitter>().maxEnergy += particleBlock;

				return;
			}

		}
	}
	
	
	
	
}
