using UnityEngine;
using System.Collections;

public class IntroductionInteractions : MonoBehaviour 
{
	public GameObject bully;
	public GameObject student;
	public GameObject barrier;

	private Vector3 bullyOriginalRotation;

	// Use this for initialization
	void Start () 
	{
		bullyOriginalRotation = bully.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void returnRotation()
	{
		iTween.RotateTo(bully, iTween.Hash("rotation", bullyOriginalRotation, "time", 1, "oncompletetarget", gameObject, "oncomplete", "unparentStudent"));
	
	}

	void unparentStudent()
	{
		student.transform.parent = null;
	}

	public void startInteraction(string objectName, string attachedWord)
	{
		// NOTE: Use '@' to start new line in transitioning thoughts
		Debug.Log("Person: " + objectName.ToString() + ", Idea: " + attachedWord.ToString());

		// Handle all trigger motion interactions in level: OfficeMary
		if (objectName == "SpecialBully")
		{
			// INCORRECT
			if (attachedWord == "Rage")
			{

				bully.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("You really get on my nerves...");
				student.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Please don't...");

				// Child student to bully
				student.transform.parent = bully.transform;

				// Make bully move (in turn making student move)
				iTween.RotateTo(bully, iTween.Hash("rotation", new Vector3(10, 0, 0), "time", 1, 
				                                   "oncompletetarget", gameObject, "oncomplete", "returnRotation"));

			}
			// CORRECT
			else if (attachedWord == "Happy")
			{
				// Possible Solution
				bully.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Hahaha, you're too funny kid.@I'll let you off this time!");
				student.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("What?@... Ugh... Okay!");

				// Lerp bully's arm rotation
				Vector3 upperArmLeftRotation = new Vector3(0, 20, 105);
				Vector3 upperArmRightRotation = new Vector3(5, 225, 105);

				GameObject upperLeftArm = new GameObject();
				GameObject upperRightArm = new GameObject();

				Transform[] allChildren = bully.GetComponentsInChildren<Transform>();
				foreach (Transform child in allChildren) 
				{
					if (child.gameObject.name == "Upper_Arm_Left")
					{
						upperLeftArm = child.gameObject;
					}
					else if (child.gameObject.name == "Upper_Arm_Right")
					{
						upperRightArm = child.gameObject;
					}
				}

				// Rotate Upper arms
				iTween.RotateTo(upperLeftArm, upperArmLeftRotation, 1);
				iTween.RotateTo(upperRightArm, upperArmRightRotation, 1);

				// iTween Path Student's position backwards
				student.GetComponent<FollowPath>().pathName = "Back Away";
				student.GetComponent<FollowPath>().triggerPath = true;

				// Since this is a valid answer, remove mouse selection
				Destroy(bully.transform.FindChild("SpecialBully").GetComponent<MouseSelection>());
				Destroy(student.transform.FindChild("SpecialKid").GetComponent<MouseSelection>());

				GetComponent<MouseLook>().enabled = true;
				GetComponent<PlayerGUI>().buttonAlpha = 0;
				transform.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
				Screen.lockCursor = true;
				Screen.showCursor = false;

				GetComponent<PlayerGUI>().crosshairAlpha = 1;

			}
			// CORRECT
			else if (attachedWord == "Compassion")
			{
				// Possible solution
				barrier.GetComponent<TransitionBarrier>().lockBarrier = false;

				// Possible Solution
				bully.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Aw geez, stop looking so scared!@It's bumming me out...");
				student.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Ugh...@O... Okay?");

				// Lerp bully's arm rotation
				Vector3 upperArmLeftRotation = new Vector3(0, 20, 105);
				Vector3 upperArmRightRotation = new Vector3(5, 225, 105);
				
				GameObject upperLeftArm = new GameObject();
				GameObject upperRightArm = new GameObject();
				
				Transform[] allChildren = bully.GetComponentsInChildren<Transform>();
				foreach (Transform child in allChildren) 
				{
					if (child.gameObject.name == "Upper_Arm_Left")
					{
						upperLeftArm = child.gameObject;
					}
					else if (child.gameObject.name == "Upper_Arm_Right")
					{
						upperRightArm = child.gameObject;
					}
				}
				
				// Rotate Upper arms
				iTween.RotateTo(upperLeftArm, upperArmLeftRotation, 1);
				iTween.RotateTo(upperRightArm, upperArmRightRotation, 1);
				
				// iTween Path Student's position backwards
				student.GetComponent<FollowPath>().pathName = "Back Away";
				student.GetComponent<FollowPath>().triggerPath = true;

				// Since this is a valid answer, remove mouse selection
				Destroy(bully.transform.FindChild("SpecialBully").GetComponent<MouseSelection>());
				Destroy(student.transform.FindChild("SpecialKid").GetComponent<MouseSelection>());

				GetComponent<MouseLook>().enabled = true;
				GetComponent<PlayerGUI>().buttonAlpha = 0;
				transform.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
				Screen.lockCursor = true;
				Screen.showCursor = false;

				GetComponent<PlayerGUI>().crosshairAlpha = 1;
			}
		}
		if (objectName == "SpecialKid")
		{
			// CORRECT
			if (attachedWord == "Rage")
			{
				Debug.Log("TRANSFORMATION COMMENCE");
				// ARMS
				GameObject upperRightArm = new GameObject();
				GameObject lowerRightArm = new GameObject();
				GameObject rightHand = new GameObject();

				GameObject upperLeftArm = new GameObject();
				GameObject lowerLeftArm = new GameObject();
				GameObject leftHand = new GameObject();

				// LEGS
				GameObject upperRightLeg = new GameObject();
				GameObject lowerRightLeg = new GameObject();

				GameObject upperLeftLeg = new GameObject();
				GameObject lowerLeftLeg = new GameObject();

				Transform[] allChildren = student.GetComponentsInChildren<Transform>();
				foreach (Transform child in allChildren) 
				{
					// Left arm assignments
					if (child.gameObject.name == "Upper_Arm_Left")
					{
						upperLeftArm = child.gameObject;
					}
					else if (child.gameObject.name == "Lower_Arm_Left")
					{
						lowerLeftArm = child.gameObject;
					}
					else if (child.gameObject.name == "Hand_Left")
					{
						leftHand = child.gameObject;
					}

					// Right arm assignments
					else if (child.gameObject.name == "Upper_Arm_Right")
					{
						upperRightArm = child.gameObject;
					}
					else if (child.gameObject.name == "Lower_Arm_Right")
					{
						lowerRightArm = child.gameObject;
					}
					else if (child.gameObject.name == "Hand_Right")
					{
						rightHand = child.gameObject;
					}

					// Left leg assignments
					else if (child.gameObject.name == "Upper_Leg_Left")
					{
						upperLeftLeg = child.gameObject;
					}
					else if (child.gameObject.name == "Lower_Leg_Left")
					{
						lowerLeftLeg = child.gameObject;
					}

					// Right leg assignments
					else if (child.gameObject.name == "Upper_Leg_Right")
					{
						upperRightLeg = child.gameObject;
					}
					else if (child.gameObject.name == "Lower_Leg_Right")
					{
						lowerRightLeg = child.gameObject;
					}
				}

				// ROTATION VECTORS
				// Upper right arm: (67, 90, 308)
				Vector3 upperRightArmRotation = new Vector3(67, 90, 308);
				// Lower right arm: (0, 230, 93)
				Vector3 lowerRightArmROtation = new Vector3(0, 230, 93);
				// Right hand: (-23, -4, -70)
				Vector3 rightHandRotation = new Vector3(-23, -4, -70);
				
				// Upper right leg: (357, 177, 342)
				Vector3 upperRightLegRotation = new Vector3(357, 177, 342);
				// Lower right leg: (33, 383, 27)
				Vector3 lowerRightLegRotation = new Vector3(33, 383, 27);
				
				// LEFT
				// Upper left arm: (287, 97, 0)
				Vector3 upperLeftArmRotation = new Vector3(287, 97, 0);
				// Lower left arm: (10, 186, 261)
				Vector3 lowerLeftArmRotation = new Vector3(10, 186, 261);
				// Left hand: (348, 13, 406)
				Vector3 leftHandRotation = new Vector3(348, 13, 406);
				
				// Upper left leg: (346, 171, 27)
				Vector3 upperLeftLegRotation = new Vector3(346, 171, 27);
				// Lower left leg: (18, 6, 327)
				Vector3 lowerLeftLegRotation = new Vector3(18, 6, 327);

				// Since iTween is being stupid and not working, I'm temporarily just hard changing the
				// rotations (why can't iTween rotate local euler angles? the world may never know)
				upperRightArm.transform.localEulerAngles = upperRightArmRotation;
				lowerRightArm.transform.localEulerAngles = lowerRightArmROtation;
				rightHand.transform.localEulerAngles = rightHandRotation;

				upperLeftArm.transform.localEulerAngles = upperLeftArmRotation;
				lowerLeftArm.transform.localEulerAngles = lowerLeftArmRotation;
				leftHand.transform.localEulerAngles = leftHandRotation;

				upperLeftLeg.transform.localEulerAngles = upperLeftLegRotation;
				lowerLeftLeg.transform.localEulerAngles = lowerLeftLegRotation;

				upperRightLeg.transform.localEulerAngles = upperRightLegRotation;
				lowerRightLeg.transform.localEulerAngles = lowerRightLegRotation;                                               

				student.GetComponent<FollowPath>().pathName = "Step Down";
				student.GetComponent<FollowPath>().triggerPath = true;

				bully.GetComponent<FollowPath>().pathName = "Back Off";
				bully.GetComponent<FollowPath>().triggerPath = true;

				// Lerp bully's arm rotation
				Vector3 upperArmLeftRotation = new Vector3(0, 20, 105);
				Vector3 upperArmRightRotation = new Vector3(5, 225, 105);
				
				upperLeftArm = new GameObject();
				upperRightArm = new GameObject();
				
				allChildren = bully.GetComponentsInChildren<Transform>();
				foreach (Transform child in allChildren) 
				{
					if (child.gameObject.name == "Upper_Arm_Left")
					{
						upperLeftArm = child.gameObject;
					}
					else if (child.gameObject.name == "Upper_Arm_Right")
					{
						upperRightArm = child.gameObject;
					}
				}
				
				// Rotate Upper arms
				iTween.RotateTo(upperLeftArm, upperArmLeftRotation, 1);
				iTween.RotateTo(upperRightArm, upperArmRightRotation, 1);

				// Change thought text
				student.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("All of you guys piss me off.@Leave me alone or else.");
				bully.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Look, he has a spine!");

				// Since this is a valid answer, remove mouse selection
				Destroy(bully.transform.FindChild("SpecialBully").GetComponent<MouseSelection>());
				Destroy(student.transform.FindChild("SpecialKid").GetComponent<MouseSelection>());

				GetComponent<MouseLook>().enabled = true;
				GetComponent<PlayerGUI>().buttonAlpha = 0;
				transform.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
				Screen.lockCursor = true;
				Screen.showCursor = false;

				GetComponent<PlayerGUI>().crosshairAlpha = 1;
			}
			// INCORRECT
			else if (attachedWord == "Happy")
			{
				// Possible solution
				barrier.GetComponent<TransitionBarrier>().lockBarrier = false;

				// Change thought text
				student.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Haha come on man, relax!@Let's get some ice cream!");
				bully.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("I'LL get some ice cream@when you give me your money!");
			}
			// CORRECT
			else if (attachedWord == "Compassion")
			{
				// Possible solution
				barrier.GetComponent<TransitionBarrier>().lockBarrier = false;

				// Change thought text
				student.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("I overheard your conversation.@Parents can really be a pain sometimes...");
				bully.transform.FindChild("Thought").GetComponent<ThoughtBubble>().transitionThought("Y... Yeah. They sure can...");

				// Rotate Bully body parts
				// Lerp bully's arm rotation
				Vector3 upperArmLeftRotation = new Vector3(0, 20, 105);
				Vector3 upperArmRightRotation = new Vector3(5, 225, 105);
				
				GameObject upperLeftArm = new GameObject();
				GameObject upperRightArm = new GameObject();
				
				Transform[] allChildren = bully.GetComponentsInChildren<Transform>();
				foreach (Transform child in allChildren) 
				{
					if (child.gameObject.name == "Upper_Arm_Left")
					{
						upperLeftArm = child.gameObject;
					}
					else if (child.gameObject.name == "Upper_Arm_Right")
					{
						upperRightArm = child.gameObject;
					}
				}
				
				// Rotate Upper arms
				iTween.RotateTo(upperLeftArm, upperArmLeftRotation, 1);
				iTween.RotateTo(upperRightArm, upperArmRightRotation, 1);

				bully.GetComponent<FollowPath>().pathName = "Back Off";
				bully.GetComponent<FollowPath>().triggerPath = true;

				student.GetComponent<FollowPath>().pathName = "Step Down";
				student.GetComponent<FollowPath>().triggerPath = true;

				// Since this is a valid answer, remove mouse selection
				Destroy(bully.transform.FindChild("SpecialBully").GetComponent<MouseSelection>());
				Destroy(student.transform.FindChild("SpecialKid").GetComponent<MouseSelection>());

				GetComponent<MouseLook>().enabled = true;
				GetComponent<PlayerGUI>().buttonAlpha = 0;
				transform.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
				Screen.lockCursor = true;
				Screen.showCursor = false;

				GetComponent<PlayerGUI>().crosshairAlpha = 1;

			}
		}
	}
}
