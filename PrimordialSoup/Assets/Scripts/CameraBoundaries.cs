using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour {


	public Generator generator;
	public Vector2 min, max;
	public Vector3 pos;
	public Camera cam;

	GameObject player;

	bool sizeSet = false;

	public float height, width, halfht, halfwd;
	
	void Awake() {
		cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		halfht = height / 2;
		halfwd = width / 2;
	}

	// Use this for initialization
	void Start () {
		generator.GetComponent<Generator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (player == null) {
			GameObject go = GameObject.FindGameObjectWithTag("Player");
			if (go != null) {
				player = go; 
			}
		}



		pos = cam.transform.position;

		if (sizeSet == false) {
			min = generator.tileGrid [0, 0].transform.position;
			max = generator.tileGrid [generator.maxX - 1, generator.maxY - 1].transform.position;
			sizeSet = true;
		}

		if (player != null) {
			pos = new Vector3 (player.transform.position.x, player.transform.position.y, -1); 
		}

		if (pos.x > max.x-halfwd) {
			pos.x = max.x-halfwd;

		} else if (pos.y > max.y-halfht) {
			pos.y = max.y-halfht;

		} else if (pos.x < min.x+halfwd) {
			pos.x = min.x+halfwd;

		} else if(pos.y < min.y+halfht) {
			pos.y = min.y+halfht;

		}
			
		cam.transform.position = pos;

	}
}
