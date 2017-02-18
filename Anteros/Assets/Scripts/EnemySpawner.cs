﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public List<GameObject> blueTiles;
	public List<GameObject> enemies;
	Object[] sublist;

	public int currentEnemies=0;
	public int maxEnemies;


	public float period = 0.0f;

	ChunkGenerate generator;
	void Awake() {
		sublist = Resources.LoadAll<GameObject> ("NeutralEnemies");
		generator = GetComponent<ChunkGenerate> ();
		blueTiles = generator.blues;
		foreach (GameObject enemy in sublist) 
		{    
			GameObject lo = (GameObject)enemy;

			enemies.Add(lo);
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (period > 30) {
			if (blueTiles.Count != 0) {
				spawnEnemies ();
			}
			period = 0;
		}

		period += Time.deltaTime;

	}

	public void spawnEnemies(){
		if (currentEnemies < maxEnemies) {
			for (int i = currentEnemies; i < maxEnemies; i++) {
				GameObject ene = enemies [Random.Range (0, enemies.Count)];
				Vector2 loc;
				GameObject tile = blueTiles [Random.Range (0, blueTiles.Count)];
				loc = new Vector2 (tile.transform.position.x, tile.transform.position.y);
				GameObject temp = (GameObject)Instantiate (ene, loc, ene.transform.rotation);
				temp.transform.parent = generator.transform;
				currentEnemies++;
			}
		}

	}
}
