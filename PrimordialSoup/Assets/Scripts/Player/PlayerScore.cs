using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int hearts = 0;
	public int greenCol = 0;
	public int redCol = 0;
	public int yellowCol = 0;
	public Text guiHearts;
	public Text guiGreens;
	public Text guiReds;
	public Text guiYellows;

	// Use this for initialization
	void Start () {
		guiHearts = GameObject.Find ("Hearts").GetComponent<Text> ();
		guiGreens = GameObject.Find ("Greens").GetComponent<Text> ();
		guiReds = GameObject.Find ("Reds").GetComponent<Text> ();
		guiYellows = GameObject.Find ("Yellows").GetComponent<Text> ();

	}

	public void green() {
		greenCol++;
		guiGreens.text = ("Greens: " + greenCol.ToString ());
	}

	public void red() {
		redCol++;
		guiReds.text = ("Reds: " + redCol.ToString ());
	}

	public void yellow() {
		yellowCol++;
		guiYellows.text = ("Yellows: " + yellowCol.ToString ());
	}

	public void heart() {
		hearts++;
		guiHearts.text = ("Hearts: " + hearts.ToString ());
	}
}
