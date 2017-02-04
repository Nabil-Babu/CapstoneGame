using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
	public float nextFire = 0.5f;

	public AudioClip shootSound;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
	private bool isShoot = true;

	PlayerHealth playerHealth;

	void Awake () {

		source = GetComponent<AudioSource>();
		playerHealth = GetComponent<PlayerHealth>();

	}

	// Update is called once per frame
	void Update () {

		if (playerHealth.isPlayerDead()) {
			isShoot = false;
		}

		else if (Input.GetButton ("Fire1") && Time.time > nextFire && isShoot) {
			Shoot ();
		}

	}

	void Shoot() {
		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(shootSound,vol);
		nextFire = Time.time + fireRate;
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}

}
