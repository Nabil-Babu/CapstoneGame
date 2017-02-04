using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);
	public int shotDamage = 10;

	private bool isDead;

	public AudioClip gameOver;

	private AudioSource source;

	PlayerMovement playerMovement;
	bool damaged;

	void Awake() {
		playerMovement = GetComponent <PlayerMovement> ();
		currentHealth = startingHealth;
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

		if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime); //fade from red to clear by flashSpeed
		}
		damaged = false;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "EnemyShot") {
			TakeDamage (shotDamage);
		}
	}

	public void Heal (int amount) {
		if (currentHealth != 0) {
			currentHealth += amount;
			healthSlider.value = currentHealth;
		}
	}

	public void TakeDamage (int amount){
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			
			Death ();
		}
	}

	void Death () {
		isDead = true;
		source.PlayOneShot(gameOver,1);
		playerMovement.enabled = false;
	}

	public bool isPlayerDead(){
		return isDead;
	}
}
