using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;
	public int shotDamage = 10;

	public GameObject enemyHeart;

	GameObject player;

	bool isDead;
	bool damaged;

	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
		player = GameObject.FindWithTag ("Player");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Shot") {
			TakeDamage (shotDamage);
		}
	}

	void Update () {
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	public void TakeDamage (int amount){
		damaged = true;
		currentHealth -= amount;
	}

	void Death(){
		isDead = true;
		Instantiate (enemyHeart, transform.position , transform.rotation);
		Destroy (gameObject, 0.2f);
	}
}
