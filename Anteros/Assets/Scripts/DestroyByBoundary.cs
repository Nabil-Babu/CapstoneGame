using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	GameObject shot;

	void Update () {
		shot = GameObject.FindWithTag ("Shot");
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == shot) {
			Destroy (other.gameObject);	
		}
	}
}