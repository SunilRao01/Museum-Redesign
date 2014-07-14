using UnityEngine;
using System.Collections;

public class TestText : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0.04f, 0.03f, 0), "time", 3, 
		                                       "easetype", iTween.EaseType.easeOutElastic));//, "looptype", iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
