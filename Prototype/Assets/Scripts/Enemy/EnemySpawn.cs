using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	GameObject enemy;

	// Use this for initialization
	void Awake () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy" && Random.value < 0.2) {
			Spawn ();
		}
	}

	void Spawn () {
		Debug.Log ("Spawn new Enemy.");
		Vector3 position = new Vector3 (Random.Range (-15.0f, 15.0f), Random.Range (-17.0f, 17.0f), 0);  
		EnemyHealth enemyHealth = enemy.GetComponent <EnemyHealth> ();
		EnemyMovement enemyMovement = enemy.GetComponent <EnemyMovement> ();
		enemyHealth.startingHealth = Random.Range(10,200);
//		enemyMovement.targetDistance += 5;
		enemy.transform.localScale = (new Vector3 (enemyHealth.startingHealth/500.0f, enemyHealth.startingHealth/500.0f, 0) );
		enemyMovement.speed = Random.Range (1.0f, 10.0f);
		enemyMovement.targetDistance = Random.Range(1.0f,30.0f);
		Instantiate (enemy, position, Quaternion.identity);
	}
}
