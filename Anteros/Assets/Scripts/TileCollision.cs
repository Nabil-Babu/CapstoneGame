using UnityEngine;
using System.Collections;

public class TileCollision : MonoBehaviour {

	public GameObject groundTile;
	public GameObject enemy;
	public GameObject itemDrop;
	public int startingHealth = 1;
	private int currentHealth = 1;

	//chance something good will drop (0-100%)
	public int lowTierChance = 10;
	public int midTierChance = 75;
	public int highTierChance = 15;

	GameObject player;
	PlayerModel playerModel;

	Color colorTmp;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		startingHealth = Random.Range (startingHealth, (startingHealth + 5));
		currentHealth = startingHealth;
		player = GameObject.FindWithTag ("Player");
		playerModel = player.GetComponent<PlayerModel> ();
		colorTmp = GetComponent<SpriteRenderer> ().color;
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "melee") {
			Damaged ();
		}
	}

	void Death() {
		Instantiate (groundTile, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), groundTile.transform.rotation);

		if (gameObject.tag == "lowTier") { //ROCK: low-tier - small chance to drop heart
			Destroy (gameObject);
			playerModel.addTile(gameObject.name.Replace("(Clone)",""));
		}

		if (gameObject.tag == "midTier") { //COPPER AND IRON: mid-tier - chance to drop mid-tier item
			int i = Random.Range (0, 100);
			if (i >= midTierChance) {
				Destroy (gameObject);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			} else if (i <= midTierChance) {
				Destroy (gameObject);
				Instantiate (itemDrop, transform.position , transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			}
		}

		if (gameObject.tag == "highTier") { //GOLD: high-tier - chance to drop mid-tier item 
			int i = Random.Range (0, 100);
			if (i >= highTierChance) {
				Destroy (gameObject);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			} else if (i <= highTierChance) {
				Destroy (gameObject);
				Instantiate (itemDrop, transform.position , transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			}
		}
	}

	void Damaged(){
		currentHealth--;
		float alpha = ((float)currentHealth / (float)startingHealth);
		Debug.Log (currentHealth + " / " + startingHealth + " = " + alpha);
		sprite.color = new Color (colorTmp.r, colorTmp.g, colorTmp.b, alpha);
		colorTmp = sprite.color;
		if (currentHealth <= 0) {
			Death ();
		}
	}
}
