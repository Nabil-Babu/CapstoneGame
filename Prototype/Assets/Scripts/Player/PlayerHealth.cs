﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	PlayerMovement playerMovement;
	bool isDead;
	bool damaged;

	void Awake() {
		playerMovement = GetComponent <PlayerMovement> ();
		currentHealth = startingHealth;
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

		playerMovement.enabled = false;
	}
}
