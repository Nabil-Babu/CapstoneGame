using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int startingScore = 0;
	public int currentScore;
	public int startCollected = 0;
	public int collected;
	public Text guiScore;
	public Text guiHearts;

	// Use this for initialization
	void Start () {
		currentScore = startingScore;
		collected = startCollected;
	}

	public void ScoreUpdate (int amount) {
		currentScore += amount;
		guiScore.text = ("Player Score: " + currentScore.ToString ());
	}
	public void CollectUpdate () {
		collected += 1;
		Debug.Log (collected);
		guiHearts.text = ("Hearts Collected: " + collected.ToString ());
	}

}
