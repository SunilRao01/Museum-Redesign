using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	/*
	 * HOW TO USE:
	 * - First, make sure you have the 'iTween' script somewhere in
	 *   the project hieierchy
	 * - In order to use this script, simply attach it to a door
	 * - Then you will need to attach a box collider (triggered) next
	 *   and shape the collider as an interactable zone for the player
	 * 
	 * 
	 * */

	private bool canOpen = false;
	private float doorSpeed = 2;

	private Vector3 doorRotation;
	private float timeIterator = 0;

	private Vector3 closeRotation;
	private Vector3 openRotation;

	public bool exit;
	public bool portal;
	public string accessPoint;

	private GameObject mainCamera;

	// Use this for initialization
	void Start () 
	{
		closeRotation = transform.rotation.eulerAngles;

		openRotation = new Vector3(0, closeRotation.y + 255, 0);

		if (exit)
		{
			openRotation = new Vector3(0, closeRotation.y - 255, 0);
		}

		mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeIterator++;

		// If door is open
		if (transform.eulerAngles == openRotation)
		{
			doorRotation = closeRotation;
 		}
		// If door is closed
		else if (transform.eulerAngles == closeRotation)
		{
			doorRotation = openRotation;
		}


		

		if (canOpen && Input.GetKeyDown(KeyCode.E))
		{
			audio.Play();

			iTween.RotateTo(gameObject, doorRotation, doorSpeed);
			//audio.Play();

			if (portal)
			{
				PlayerPrefs.SetString("PreviousScene", Application.loadedLevelName.ToString());

				mainCamera.GetComponent<FadeOut>().nextScene = accessPoint;
				mainCamera.GetComponent<FadeOut>().fade = true;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			canOpen = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			canOpen = false;
		}
	}
}
