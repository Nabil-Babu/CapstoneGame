using UnityEngine;
using System.Collections;

public class TileCollision : MonoBehaviour {

	public GameObject groundTile;
	public GameObject enemy;
	public GameObject itemDrop;
	public int health = 1;

	GameObject player;
	PlayerModel playerModel;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		playerModel = player.GetComponent<PlayerModel> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "melee") {
			health--;
			if (health <= 0) {
				Death ();
			}
		}
	}

	void Death() {
		Instantiate (groundTile, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), groundTile.transform.rotation);
		if (gameObject.tag == "green") {
			Destroy (gameObject);
			playerModel.addTile(gameObject.name.Replace("(Clone)",""));
		}
		if (gameObject.tag == "red") {
			int i = Random.Range (0, 100);
			if (i <= 25) {
				Destroy (gameObject);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			} else if (i >= 25) {
				Destroy (gameObject);
				Instantiate (itemDrop, transform.position , transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			}
		}
		if (gameObject.tag == "yellow") {
			int i = Random.Range (0, 100);
			if (i <= 10) {
				Destroy (gameObject);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			} else if (i >= 10) {
				Destroy (gameObject);
				Instantiate (itemDrop, transform.position , transform.rotation);
				playerModel.addTile(gameObject.name.Replace("(Clone)",""));
			}
		}
	}
}
