using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	GameObject player;
	PlayerScore playerScore;

	public GameObject enemy;

	bool enemyAlive;

	// Use this for initialization
	void Awake () {

		player = GameObject.FindWithTag ("Player");
		playerScore = player.GetComponent <PlayerScore> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.FindWithTag ("Enemy") == null) {
			enemyAlive = false;
		}

		if (playerScore.currentScore != 0 && playerScore.currentScore % 100 == 0 && enemyAlive == false) {
			Spawn ();
		}

	}

	void Spawn () {
		
		Debug.Log ("Spawn new Enemy.");
		Vector3 position = new Vector3 (Random.Range (-15.0f, 15.0f), Random.Range (-17.0f, 17.0f), 0);  
		EnemyHealth enemyHealth = enemy.GetComponent <EnemyHealth> ();
		EnemyMovement enemyMovement = enemy.GetComponent <EnemyMovement> ();
		enemyHealth.startingHealth += 100;
		enemyMovement.targetDistance += 5;
		Instantiate (enemy, position, Quaternion.identity);
		enemyAlive = true;
		Debug.Log ("Enemy Health: " + enemyHealth.currentHealth);
	}
}
