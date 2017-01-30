using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillDeath : MonoBehaviour {

	public float timer = 0.1f;
	PlayerMelee player; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMelee> ();

	}

	// Update is called once per frame
	void Update () {
		timer = timer - Time.deltaTime;

		gameObject.transform.position = player.meleeSpot.transform.position;


		if (timer <= 0) {
			Death ();
		}
	}

	void Death() {
		Destroy (gameObject);
	}
}
