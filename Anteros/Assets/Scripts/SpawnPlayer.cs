﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {


	Generator generator;

	public GameObject playerPrefab;
	public List<GameObject> blues;

	private Vector2 centerPoint;
	private Vector2 playerSpawn;

	// Use this for initialization
	void Start () {
		generator = GetComponent<Generator> ();
		blues = generator.blues;
		centerPoint = generator.centerPoint;
	}

	// Update is called once per frame
	void Update () {

	}

	public void spawnPlayer() {

		float xPos = 0;
		float yPos = 0;


		float cDist = 0; //Current blue tile that is the closest to the center of the map. 


		for (int i = 0; i < blues.Count - 1; i++) {
			if ((int)centerPoint.x == (int)blues [i].transform.position.x) {
				float d = Vector2.Distance (centerPoint, blues[i].transform.position);
				if (cDist == 0) {
					cDist = d;
					playerSpawn = new Vector2(blues[i].transform.position.x,blues[i].transform.position.y);

				} else {
					if (d < cDist) {
						cDist = d;
						playerSpawn = new Vector2(blues[i].transform.position.x,blues[i].transform.position.y);

					}
				}
			}
		}



		Instantiate (playerPrefab, playerSpawn, playerPrefab.transform.rotation);

	}
}
