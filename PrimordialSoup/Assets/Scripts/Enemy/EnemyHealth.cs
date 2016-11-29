using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;
	public GameObject enemyHeart;

	bool isDead;
	bool damaged;


	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
		damaged = false;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "bullet") {
			TakeDamage (10);
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
