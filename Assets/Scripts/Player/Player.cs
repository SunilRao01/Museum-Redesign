using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public ArrayList currentWords;
	public string words;
	public GUIText zenGUI;

	public bool lockMovement;	

	public float zen = 0;
	
	public bool hasKey = false;

	public bool debug;

	public int bossHealth;
	public int maxBossHealth;


	void Awake () 
	{
		currentWords = new ArrayList();
	}

	void Start()
	{
		addWord("Blocks");
		addWord("Water");
		addWord("Fire");
		addWord("Rage");
	}
	
	void Update()
	{

	}

	void updateWords()
	{
		words = "";

		for (int i = 0; i < currentWords.Count; i++)
		{
			words += currentWords[i] + System.Environment.NewLine + System.Environment.NewLine;
		}

		//words.text = words.text.Replace("@", System.Environment.NewLine);
	}

	// Show effect when adding zen
	public void addZen(ref int currentZen)
	{
		currentZen++;
	}

	public void zenUp()
	{
		zen++;
	}

	// TODO: Show effects when adding/remove words
	public void addWord(string word)
	{
		currentWords.Add(word);
		updateWords();
	}

	public void removeWord(int position)
	{
		currentWords.RemoveAt(position);
		updateWords();
	}
}
