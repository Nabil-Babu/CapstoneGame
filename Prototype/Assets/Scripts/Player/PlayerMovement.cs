using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	public float rotHSpeed = 2.0F;
	public float rotVSpeed = 2.0F;

	public int healAmnt = 10;
	PlayerHealth playerHealth;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		playerHealth = GetComponent<PlayerHealth> ();

	}

	void FixedUpdate () {
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rb2d.angularVelocity = 0;

		Vector2 movement = new Vector2 (moveH, moveV);
		rb2d.AddForce (movement * speed);

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			Destroy (other.gameObject);
			playerHealth.Heal(healAmnt);
		}
	}
}
