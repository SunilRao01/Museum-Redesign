using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour 
{
	public string nextScene;

	private GameObject cameraObject;

	void Start () 
	{
		cameraObject = GameObject.Find("Main Camera");
	}
	
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("FDFDFDFDFD");

			cameraObject.GetComponent<FadeOut>().nextScene = nextScene;
			cameraObject.GetComponent<FadeOut>().fade = true;
		}
	}

	void OnTriggerExit(Collider other)
	{

	}
}
