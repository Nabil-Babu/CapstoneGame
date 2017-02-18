using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	private PlayerModel playerModel;

	public float speed;
	public float rotHSpeed = 2.0F;
	public float rotVSpeed = 2.0F;

	public AudioClip collectItem;

	private AudioSource source;

	private PlayerHealth playerHealth;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		playerHealth = GetComponent<PlayerHealth> ();
		source = GetComponent<AudioSource>();
		playerModel = GetComponent<PlayerModel> ();
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
		
		if (other.gameObject.CompareTag ("item")) {
			source.PlayOneShot(collectItem,1);
			playerModel.addItem (other.gameObject.name.Replace("(Clone)",""));
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("heart")) {
			playerHealth.Heal (10);
			source.PlayOneShot(collectItem,1);
			playerModel.addItem (other.gameObject.name.Replace("(Clone)",""));
			Destroy (other.gameObject);
		}

	}
}
