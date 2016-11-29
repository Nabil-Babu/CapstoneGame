using UnityEngine;
using System.Collections;

public class TileCollision : MonoBehaviour {

	public GameObject blueTile;
	public GameObject enemy;
	public int health = 1;

	PlayerScore score; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			health--;
			if (health <= 0) {
				score = coll.gameObject.GetComponent<PlayerScore> ();
				Death ();
			}
		} 

	}

	void Death() {
		Instantiate (blueTile, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), blueTile.transform.rotation);
		if (gameObject.tag == "green") {
			score.green ();
		}
		if (gameObject.tag == "red") {
			score.red ();
			int i = Random.Range (0, 100);
			if (i <= 50) {
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
			}
		}
		if (gameObject.tag == "yellow") {
			score.yellow ();
			int i = Random.Range (0, 100);
			if (i <= 75) {
				Instantiate (enemy, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), enemy.transform.rotation);
			}
		}
		Destroy (gameObject);
	}
}
