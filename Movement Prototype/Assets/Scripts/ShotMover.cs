using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {

	public float speed;
	public int shotDamage = 10;

	private Rigidbody2D rb2d;
	GameObject enemy;
	EnemyHealth enemyHealth;

	bool enemyHit;

	// Use this for initialization
	void Awake () {
		if (GameObject.FindWithTag ("Enemy") != null) {
			enemy = GameObject.FindWithTag ("Enemy");
			enemyHealth = enemy.GetComponent <EnemyHealth> ();
		}
		rb2d = GetComponent <Rigidbody2D> ();
		rb2d.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == enemy) {
			enemyHit = true;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == enemy) {
			enemyHit = false;
		}
	}

	void Update () {
		if (enemyHit) {
			Damage ();
		}
	}

	void Damage () {
		if (enemyHealth.currentHealth > 0) {
			enemyHealth.TakeDamage (shotDamage);
			Destroy (gameObject);
		}
	}
}
	