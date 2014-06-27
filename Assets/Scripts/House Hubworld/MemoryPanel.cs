using UnityEngine;
using System.Collections;

public class MemoryPanel : MonoBehaviour 
{
	private GameObject playerObject;

	void Start () 
	{
		playerObject = GameObject.Find("Player");
	}
	
	void Update () 
	{
		transform.LookAt(playerObject.transform.position);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
	}
}
