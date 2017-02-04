using UnityEngine;
using System.Collections;

public class EnemyStationary : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed = 3f;
	public Transform target;
	public float targetDistance = 10f;

	float x;
	float y;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		target = GameObject.FindWithTag ("Player").transform;
		x = transform.position.x;
		y = transform.position.y;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Stationary();
	}

	void Stationary() {
		if (Vector3.Distance (transform.position, target.position) < targetDistance) { 
			transform.LookAt (target.position);
			transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		}
	}
}

