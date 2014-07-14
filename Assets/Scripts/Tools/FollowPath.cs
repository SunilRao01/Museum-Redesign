using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour 
{
	// Path variables
	public string pathName;
	public float pathSpeed;

	public bool triggerPath = false;
	public bool orientToPath;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (triggerPath)
		{
			iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "speed", pathSpeed, 
			                                      "easetype", iTween.EaseType.linear, "orienttopath", orientToPath));
			triggerPath = false;
		}
	}
}
