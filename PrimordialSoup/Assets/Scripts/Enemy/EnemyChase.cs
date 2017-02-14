using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

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
		Chase();
	}

	void Chase(){
		if (Vector3.Distance (transform.position, target.position) < targetDistance) { //if player in range follow
			transform.LookAt (target.position);
			transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
	}
}

