using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;
	public GameObject enemyHeart;

	GameObject player;
	PlayerScore playerScore;

	bool isDead;
	bool damaged;


	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
		player = GameObject.FindWithTag ("Player");
		playerScore = player.GetComponent <PlayerScore> ();
	}
	
	// Update is called once per frame
	void Update () {

		//if (damaged) {
			//Debug.Log ("Enemy Health: " + currentHealth);
		//}
		damaged = false;
	}

	public void TakeDamage (int amount){
		damaged = true;
		currentHealth -= amount;
		playerScore.ScoreUpdate (scoreValue);
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	void Death(){
		isDead = true;
		Instantiate (enemyHeart, transform.position , transform.rotation);
		Destroy (gameObject, 0.2f);
	}
}
