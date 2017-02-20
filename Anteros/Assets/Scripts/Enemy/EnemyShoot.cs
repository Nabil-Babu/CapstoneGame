using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 2f;
	public float nextFire = 1f;
	public int shotDamage = 10;

	public AudioClip shootSound;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		source = GetComponent<AudioSource>();
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
			Shoot ();
		}
	}

	void Shoot() {
		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(shootSound,vol);
		nextFire = Time.time + fireRate;
		shot.GetComponent<ShotMover> ().spawnOrigin = gameObject;
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}
}
