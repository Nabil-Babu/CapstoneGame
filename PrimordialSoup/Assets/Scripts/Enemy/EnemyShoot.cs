using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 2f;
	public float nextFire = 1f;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == player) {
			playerInRange = true;

		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (Time.time > nextFire && playerInRange && enemyHealth.currentHealth > 0) {
			transform.LookAt (player.transform.position);
			transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
			Shoot ();
		}
			
	}

	void Shoot() {
		nextFire = Time.time + fireRate;
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}
}
