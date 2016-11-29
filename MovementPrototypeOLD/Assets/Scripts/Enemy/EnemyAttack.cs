using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			playerInRange = true;
			//Debug.Log ("playerInRange");
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
			//Debug.Log ("playerInRange");
		}
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange) {
			Attack ();
		}

		//if (playerHealth.currentHealth <= 0) {
			
		//}
	}

	void Attack () {
		timer = 0f;

		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
