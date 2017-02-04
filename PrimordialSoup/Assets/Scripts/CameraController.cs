using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {


		if (player == null) {
			// find player ship
			GameObject go = GameObject.FindGameObjectWithTag("Player");
			if (go != null) {
				player = go; 
			}
		}

		if (player != null) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -1); 
		}



	
	
	}
}
