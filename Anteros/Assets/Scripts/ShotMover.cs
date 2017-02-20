using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {

	public float speed;
	public GameObject spawnOrigin;

	float timer = 1;

	private Rigidbody2D rb2d;

	bool enemyHit;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent <Rigidbody2D> ();
		rb2d.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (gameObject.tag == "Shot") {
			if (other.gameObject.tag == "StationaryEnemy" || other.gameObject.tag == "WanderEnemy" || other.gameObject.tag == "GuardEnemy" || other.gameObject.tag == "ChaserEnemy") {
				Death ();
			}
		}

		if (gameObject.tag == "EnemyShot") {
			if (other.gameObject.tag == "Player") {
				Death ();
			}
		}

		if (other.gameObject.tag == "lowTier" || other.gameObject.tag == "midTier" || other.gameObject.tag == "highTier") {
			Death ();
		}


	}

	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Death ();
		}
	}

	void Death () {
		Destroy (gameObject);
	}
}
	