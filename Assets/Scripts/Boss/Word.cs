using UnityEngine;
using System.Collections;

public class Word : MonoBehaviour {

	public float moveSpeed;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").GetComponent<Transform>().position, Time.deltaTime * moveSpeed);

		// Look at player, but with a fixed y-position due to weird 3d text position angling
		transform.LookAt(GameObject.Find("Player").GetComponent<Transform>().position);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 180, transform.eulerAngles.z);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// TODO: Decrease player's 'health'
			GameObject.Find("Player").GetComponent<Player>().bossHealth--;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
