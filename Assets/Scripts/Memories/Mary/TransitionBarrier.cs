using UnityEngine;
using System.Collections;

public class TransitionBarrier : MonoBehaviour 
{
	public bool lockBarrier;
	private Player player;

	void Start () 
	{
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	void Update () 
	{
		if (lockBarrier)
		{
			GetComponent<BoxCollider>().isTrigger = false;
		}
		else
		{
			GetComponent<BoxCollider>().isTrigger = true;
		}

		if (player.zen >= int.Parse(transform.GetChild(0).GetComponent<TextMesh>().text))
		{
			lockBarrier = false;
			GetComponent<ParticleAnimator>().doesAnimateColor = false;
		}
	}
}
