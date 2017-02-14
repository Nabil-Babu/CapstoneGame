using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;

	public GameObject enemyHeart;

	GameObject player;
	PlayerModel playerModel;

	public AudioClip death;

	private AudioSource source;

	bool isDead;
	bool damaged;

	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
		player = GameObject.FindWithTag ("Player");
		playerModel = player.GetComponent<PlayerModel> ();
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Shot") {
			TakeDamage (player.GetComponent<PlayerShooting>().shotDamage);
		}

		if (other.gameObject.tag == "melee") {
			TakeDamage (player.GetComponent<PlayerMelee>().meleeDMG);
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
		source.PlayOneShot(death,1);
		playerModel.addKill (gameObject.name.Replace("(Clone)",""));
		Destroy (gameObject, 0.7f);
		Instantiate (enemyHeart, transform.position , transform.rotation);
	}
}
