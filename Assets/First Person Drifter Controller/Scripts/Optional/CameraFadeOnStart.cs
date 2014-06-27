// by @torahhorse

using UnityEngine;
using System.Collections;

public class CameraFadeOnStart : MonoBehaviour
{
	public bool fadeInWhenSceneStarts = true;
	public Color fadeColor = Color.black;
	private float fadeTime = 3f;

	void Awake ()
	{
		if( fadeInWhenSceneStarts )
		{
			Fade();
		}
	}
	
	public void Fade()
	{
		CameraFade.StartAlphaFade(fadeColor, true, fadeTime);
	}
}
