using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {

	public float speed;
	public int shotDamage = 10;

	float timer = 1;

	private Rigidbody2D rb2d;

	bool enemyHit;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent <Rigidbody2D> ();
		rb2d.velocity = transform.up * speed;
	}

	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Death (); 
		}
	}

	void Death() {
		Destroy (gameObject); 
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "enemy") {
			Death ();
		}
	}
}
	