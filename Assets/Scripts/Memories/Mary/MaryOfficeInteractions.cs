using UnityEngine;
using System.Collections;

public class MaryOfficeInteractions : MonoBehaviour 
{
	// Interactive characters
	public GameObject sadPhil;
	public GameObject plantManager;

	// Use this for initialization
	void Start () 
	{
		//sadPhil = GameObject.Find("SadPhil");
		//plantManager = GameObject.Find("PlantManager");
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
			Destroy(sadPhil.transform.GetChild(1).GetComponent<MouseSelection>());
			
			// Set object on path
			sadPhil.GetComponent<FollowPath>().triggerPath = true;
		}
		if (objectName == "PlantManager")
		{
			Debug.Log("PlantManager child count: " + plantManager.transform.childCount.ToString());

			// TODO: Fix bug where none of the code below fill work properly
			plantManager.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Last I checked, our company@isn't the most environmentally friendly...");

			Destroy(plantManager.transform.GetChild(1).GetComponent<MouseSelection>());

			plantManager.GetComponent<FollowPath>().triggerPath = true;
		}
	}
}
