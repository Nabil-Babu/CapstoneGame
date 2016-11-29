using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int startingScore = 0;
	public int currentScore;
	public Text guiScore;

	// Use this for initialization
	void Start () {
		currentScore = startingScore;
	}

	public void ScoreUpdate (int amount) {
		currentScore += amount;
		guiScore.text = ("Player Score: " + currentScore.ToString ());
	}

}
