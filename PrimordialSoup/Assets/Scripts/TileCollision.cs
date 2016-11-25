using UnityEngine;
using System.Collections;

public class TileCollision : MonoBehaviour {

	public GameObject blueTile;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Instantiate (blueTile, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), blueTile.transform.rotation);
			Destroy (gameObject);
		}
	}
}
