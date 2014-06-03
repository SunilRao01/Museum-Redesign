using UnityEngine;
using System.Collections;

public class TransitionBarrier : MonoBehaviour 
{
	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{

			// Play new music
			audio.Play();
		}
	}
}
