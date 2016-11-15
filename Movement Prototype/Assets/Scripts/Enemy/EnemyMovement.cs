using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed = 3f;
	public Transform target;
	public float targetDistance = 1f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		if (Vector3.Distance (transform.position, target.position) < targetDistance) {
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}

	}
}
