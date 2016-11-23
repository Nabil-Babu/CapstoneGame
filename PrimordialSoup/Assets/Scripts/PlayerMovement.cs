using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	public float rotHSpeed = 2.0F;
	public float rotVSpeed = 2.0F;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");


		float h = rotHSpeed * Input.mousePosition.x;
		float v = rotHSpeed * Input.mousePosition.y;

		float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg * (-1);

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Vector2 movement = new Vector2 (moveH, moveV);
		rb2d.AddForce (movement * speed);

	}
}
