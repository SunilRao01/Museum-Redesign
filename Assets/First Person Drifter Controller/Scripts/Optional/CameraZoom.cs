// by @torahhorse

using UnityEngine;
using System.Collections;

// allows player to zoom in the FOV when holding a button down
[RequireComponent (typeof (Camera))]
public class CameraZoom : MonoBehaviour
{
	public float zoomFOV = 30.0f;
	public float zoomSpeed = 9f;
	
	private float targetFOV;
	private float baseFOV;

	public bool zooming = false;
	
	void Start ()
	{
		SetBaseFOV(camera.fieldOfView);
	}
	
	void Update ()
	{
		// TODO: Remove GUI from other scenes when zooming
		if(Input.GetButton("Fire2"))
		{
			targetFOV = zoomFOV;
			zooming = true;

			// Check if player is in house hubworld
			if (Application.loadedLevelName == "HouseHub" && transform.parent.GetComponent<HubworldPlayer>().enterMemory)
			{
				transform.parent.gameObject.GetComponent<HubworldPlayer>().promptAlpha = 0;
			}
		}
		else
		{
			targetFOV = baseFOV;
			zooming = false;

			// Check if player is in house hubworld
			if (Application.loadedLevelName == "HouseHub" && transform.parent.GetComponent<HubworldPlayer>().enterMemory)
			{
				transform.parent.gameObject.GetComponent<HubworldPlayer>().promptAlpha = 1;
			}
		}
		
		UpdateZoom();
	}
	
	private void UpdateZoom()
	{
		camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
	}
	
	public void SetBaseFOV(float fov)
	{
		baseFOV = fov;
	}
}
