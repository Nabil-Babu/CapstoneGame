using UnityEngine;
using System.Collections;

public class EnemyGuard : MonoBehaviour {

	public Vector2 pointA;
	public Vector2 pointB;
	public Vector2 speed = new Vector2(3, 0);

	private Rigidbody2D rb2d;

	// Distance the object will move horizontally.x, vertically.y, and z-ically.z
	public Vector2 moveDistance = new Vector2(15, 0);

	// Enemy pace - default : always on
	public int paceDirection = 1; // 1 = move right, -1 = move left
	public Quaternion lookLeft = Quaternion.Euler(0, 0, 0);
	public Quaternion lookRight = Quaternion.Euler(0, 180, 0);

	public Transform target;
	public float targetDistance = 10f;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		pointA = rb2d.position;
		pointB = pointA + moveDistance;
		target = GameObject.FindWithTag ("Player").transform;
	}

	void FixedUpdate() 
	{

		if (Vector3.Distance (transform.position, target.position) < targetDistance) {
			Stationary ();
		} else {
			Guard ();
		}
		
	}

	void Guard() {
		// Decides pace direction, 1 = Right, -1 = Left
		if (rb2d.position.x >= pointB.x && paceDirection == 1)
		{
			paceDirection = -paceDirection;
			transform.rotation = lookRight;
		}
		else if (rb2d.position.x < pointA.x && paceDirection == -1) 
		{
			paceDirection = -paceDirection;
			transform.rotation = lookLeft;
		}

		// Moves Object with Ridgebody left and right
		rb2d.MovePosition(rb2d.position + (paceDirection * speed) * Time.deltaTime);
	}

	void Stationary() {
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
	}
		
}

