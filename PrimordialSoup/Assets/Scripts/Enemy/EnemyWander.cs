using UnityEngine;
using System.Collections;

public class EnemyWander : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed = 3f;
	public Transform target;
	public float targetDistance = 10f;

	float maxX = 15;
	float minX = -15;
	float maxY = 17;
	float minY = -17;

	float tChange = 0;
	float randomX;
	float randomY;

	float x;
	float y;

	// Use this for initialization
	void Start (){

		rb2d = GetComponent<Rigidbody2D> ();
		target = GameObject.FindWithTag ("Player").transform;
		x = transform.position.x;
		y = transform.position.y;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Wander();
	
	}

	void Wander() {
		if (Time.time >= tChange) {
			randomX = Random.Range (-2.0f, 2.0f);
			randomY = Random.Range (-2.0f, 2.0f);

			tChange = Time.time + Random.Range (0.5f, 1.5f);
		}

		transform.Translate (new Vector3 (randomX, randomY, 0) * speed * Time.deltaTime);

		//border
		if (transform.position.x >= maxX || transform.position.x <= minX) {
			randomX = -randomX;
		}
		if (transform.position.y >= maxY || transform.position.y <= minY) {
			randomY = -randomY;
		}

		x = Mathf.Clamp(transform.position.x, minX, maxX);
		y = Mathf.Clamp(transform.position.y, minY, maxY);
	}
}

