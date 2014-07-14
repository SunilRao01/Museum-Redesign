using UnityEngine;
using System.Collections;

public class ThoughtBubble : MonoBehaviour 
{
	// Thought texts
	private GameObject[] thoughtTexts;
	private int thoughtCount = 0;

	void Start () 
	{
		thoughtTexts = new GameObject[2];
		Transform[] allChildren = GetComponentsInChildren<Transform>();

		foreach (Transform child in allChildren)
		{
			if (child.gameObject.name == "Text")
			{
				thoughtTexts[thoughtCount] = child.gameObject;
				thoughtCount++;
			}
		}

		thoughtCount = 0;
	}
	
	void Update () 
	{
		
	}

	public void transitionThought(string newThought)
	{
		// TODO: If thought bubble receives a new thought, do the following:
		// 1.) Make text vanish slowly to an alpha value of 0
		// 1.) While this is happening, there will be a sound effect playing
		// 2.) Convert text into new thought
		// 3.) Make text with new thought appear back to an alpha value of 1

		// Currently just hard changes the thought, no transitional effects
		int thoughtCount = 0;
		int tempPosition = 0;
		
		for (int i = 0; i < newThought.Length; i++)
		{
			if (newThought[i].Equals('@'))
			{
				thoughtTexts[thoughtCount].GetComponent<TextMesh>().text = newThought.Substring(tempPosition, i);
				thoughtCount++;
				tempPosition = i;
			}
			if (i == (newThought.Length-1))
			{
				if (thoughtCount > 0)
				{
					thoughtTexts[thoughtCount].GetComponent<TextMesh>().text = newThought.Substring((tempPosition + 1), (i - tempPosition));
				}
				else
				{
					thoughtTexts[thoughtCount].GetComponent<TextMesh>().text = newThought.Substring((tempPosition), (i - (tempPosition-1)));
				}
				thoughtCount++;
			}
		}

		//StartCoroutine(fade(newThought));

	}

	void fadeAway(Color inputColor, float timeStep)
	{
		do
		{
			inputColor = new Color(inputColor.r, inputColor.g, inputColor.b, inputColor.a - timeStep);
		} while (inputColor.a > 0);
	}

	void fadeTo(Color inputColor, float timeStep)
	{
		do
		{
			inputColor = new Color(inputColor.r, inputColor.g, inputColor.b, inputColor.a + timeStep);
		} while (inputColor.a < 1);
	}

	IEnumerator fade(string newThought)
	{
		// Fade Away
		for (int i = 0; i < thoughtTexts.Length; i++)
		{
			//StartCoroutine(Fade.use.Alpha(thoughtTexts[i].GetComponent<TextMesh>(), 1.0f, 0.0f, 2.0f));

		}





		// Change thought
		int thoughtCount = 0;
		int tempPosition = 0;
		
		for (int i = 0; i < newThought.Length; i++)
		{
			if (newThought[i].Equals('@'))
			{
				thoughtTexts[thoughtCount].GetComponent<TextMesh>().text = newThought.Substring(tempPosition, i);
				thoughtCount++;
				tempPosition = i;
			}
			if (i == (newThought.Length-1))
			{
				thoughtTexts[thoughtCount].GetComponent<TextMesh>().text = newThought.Substring((tempPosition + 1), (i - tempPosition));
				thoughtCount++;
			}
		}


		yield return new WaitForSeconds(2);





		// Fade Back
		for (int j = 0; j < thoughtTexts.Length; j++)
		{
			fadeTo(thoughtTexts[j].renderer.material.color, 0.0001f);
		}
	}

	/*void OnMouseOver()
	{
		int i = 0;
		// Emit all thought particles
		foreach (Transform child in transform)
		{
			if (child.gameObject.name == "Thought Bubble")
			{
				if (i == 0)
				{
					// Make thought text visible
					child.FindChild("Text").GetComponent<MeshRenderer>().enabled = true;
				}

				child.GetComponent<ParticleEmitter>().emit = true;
			}

			i++;
		}


	}

	void OnMouseExit()
	{
		int i = 0;
		// Un-Emit all thought particles
		foreach (Transform child in transform)
		{
			if (child.gameObject.name == "Thought Bubble")
			{
				if (i == 0)
				{
					// Make thought text visible
					child.FindChild("Text").GetComponent<MeshRenderer>().enabled = false;
				}

				child.GetComponent<ParticleEmitter>().emit = false;
			}

			i++;
		}

	}*/
}
