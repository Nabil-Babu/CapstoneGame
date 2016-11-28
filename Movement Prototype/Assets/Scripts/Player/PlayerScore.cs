using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int startingScore = 0;
	public int currentScore;

	// Use this for initialization
	void Start () {
		currentScore = startingScore;
	}

	public void ScoreUpdate (int amount) {
		currentScore += amount;
	}
}
