using UnityEngine;
using System.Collections;

public class TileCollision : MonoBehaviour {

	public GameObject blueTile;
	public GameObject enemy;
	public int health = 1;


	// Use this for initialization
	void Start () {
		
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
		Instantiate (blueTile, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), blueTile.transform.rotation);
		if (gameObject.tag == "green") {
			
		}
		if (gameObject.tag == "red") {
			int i = Random.Range (0, 100);
			if (i <= 50) {
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
			}
		}
		if (gameObject.tag == "yellow") {
			int i = Random.Range (0, 100);
			if (i <= 75) {
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
			}
		}
		Destroy (gameObject);
	}
}
