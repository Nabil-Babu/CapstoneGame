using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveH, moveV);
		rb2d.AddForce (movement * speed);

	}
}
