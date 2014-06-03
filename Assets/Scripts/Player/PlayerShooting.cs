using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour 
{
	// Bullet prefabs
	public GameObject block;
	public GameObject aimingBlock;

	// Player GUI
	private PlayerBossGUI playerGUI;
	private string power;

	// Camera variables
	private GameObject mainCamera;
	public float aimDistance;

	private Vector3 rayPosition;

	void Start () 
	{
		playerGUI = GetComponent<PlayerBossGUI>();
		mainCamera = GameObject.Find("Main Camera");
		aimingBlock = (GameObject) Instantiate(block, Vector3.zero, Quaternion.identity);
		Destroy(aimingBlock.GetComponent<Blocks>());
	}
	
	void Update () 
	{
		// Keep what the selected power updated
		power = playerGUI.selectedPower;

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * aimDistance, Color.red);

		// If power is blocks, show where the block is going to be placed
		if (power == "Blocks")
		{
			rayPosition = mainCamera.transform.position + (mainCamera.transform.forward * aimDistance);
			aimingBlock.transform.position = rayPosition;
		}

		handleShooting();
	}

	void handleShooting()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			aimDistance++;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			aimDistance--;
		}

		if (Input.GetMouseButtonDown(0))
		{
			// TODO: SHOOTING

			// Fow now, block instantiates at end of the ray
			Ray forward = new Ray(mainCamera.transform.position, transform.forward * 10);
			Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * aimDistance, Color.red);

			// Currently/Temporarily this position is at the end of the ray
			rayPosition = mainCamera.transform.position + (mainCamera.transform.forward * aimDistance);

			if (power == "Blocks")
			{
				Instantiate(block, rayPosition, Quaternion.identity);

			}
			Debug.Log("Use power of: " + power.ToString());
		}
	}
}
