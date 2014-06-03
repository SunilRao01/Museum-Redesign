using UnityEngine;
using System.Collections;

public class MuseumInfo : MonoBehaviour 
{

	public int mainPaintingSize;
	public int mainPaintings;

	
	// Use this for initialization
	void Start () 
	{
		mainPaintings = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mainPaintings == mainPaintingSize)
		{
			// Start exit dialogue
			GetComponent<Dialogue>().start();

			// Update goals
			Player mainPlayer = GameObject.Find("Player").GetComponent<Player>();

			mainPaintingSize = 99;
		}
	}




}
