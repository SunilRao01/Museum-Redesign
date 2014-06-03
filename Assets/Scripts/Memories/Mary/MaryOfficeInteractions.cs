using UnityEngine;
using System.Collections;

public class MaryOfficeInteractions : MonoBehaviour 
{
	// Interactive characters
	private GameObject sadPhil;

	// Use this for initialization
	void Start () 
	{
		sadPhil = GameObject.Find("SadPhil");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void startInteraction(string objectName)
	{
		// Handle all trigger motion interactions in level: OfficeMary
		if (objectName == "SadPhil")
		{
			// Change thought
			sadPhil.transform.GetChild(2).GetComponent<ThoughtBubble>().transitionThought("Maybe I'll just give him a piece of my mind.@Who knows, maybe talking will make him understand.");
			
			// Make it unselectable since you finished the obstacle
			Destroy(sadPhil.transform.FindChild("SadPhil").GetComponent<MouseSelection>());
			
			// Set object on path
			sadPhil.GetComponent<FollowPath>().triggerPath = true;
		}

	}
}
