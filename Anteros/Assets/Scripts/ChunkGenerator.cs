﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour {

	public GameObject chunk;
	public GameObject tile;

	Dictionary<string, int> chunkLoadedSet;
	List<GameObject> chunks = new List<GameObject>();

	GameObject player;

	ChunkGenerate chunkgenerate;

	public int numofChunks = 3; 

	public float despawnRadius;
	public int spawnRadius;

	public float chunksize;
	public float tileSize;

	// Use this for initialization
	void Start () {
		chunkLoadedSet = new Dictionary<string, int>();
		chunkgenerate = chunk.GetComponent<ChunkGenerate> ();
		tileSize = tile.GetComponent<SpriteRenderer> ().bounds.size.x;
		chunksize = tileSize * chunkgenerate.maxX;
		GenerateChunks ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		spawnChunks ();
		despawnChunks ();
	}

	void GenerateChunks() {
		for (int i = 0; i < numofChunks; i++) {
			for (int j = 0; j < numofChunks; j++) {
				GameObject Temp = (GameObject)Instantiate (chunk, new Vector2 (i * chunksize , j * chunksize), chunk.transform.rotation);
				chunks.Add (Temp);
				chunkLoadedSet.Add (i+" "+j, 1);
			}		
		}
	}

	void spawnChunks() {
		float px = player.transform.position.x;
		float py = player.transform.position.y;

		px -= px % chunksize;
		py -= py % chunksize;

		int chunkRadius = (int)chunksize * Mathf.CeilToInt (spawnRadius / chunksize);
		for (int i = (int)px - chunkRadius; i <= (int)px + chunkRadius; i += (int)chunksize) {
			for (int j = (int)py - chunkRadius; j <= (int)py + chunkRadius; j += (int)chunksize) {
				// Check if Chunk is not already loaded and is in SpawnRange
				if (!chunkLoaded (i, j) && pointInSpawnRange (i, j, px, py)) {
					GameObject Temp = (GameObject)Instantiate (chunk, new Vector2 (i, j), chunk.transform.rotation);
					chunks.Add (Temp);
					chunkLoadedSet.Add (i + " " + j, 1);
				}
			}
		}
	}

	bool chunkLoaded(int i, int j) {
		return chunkLoadedSet.ContainsKey (i+ " " +j);
	}

	bool pointInSpawnRange(int i, int j, float px, float py) {
		int d = Mathf.FloorToInt(Vector2.Distance (new Vector2 (px, py), new Vector2 ((float)i, (float)j)));
		return d < spawnRadius;
	}

	void despawnChunks() {
		float px = player.transform.position.x;
		float py = player.transform.position.y;
		int d;

		//Despawn chunks when outside of range
		foreach (GameObject chunkpiece in chunks) {
			d = Mathf.FloorToInt(Vector2.Distance (new Vector2 (px, py), new Vector2 (chunkpiece.transform.position.x, chunkpiece.transform.position.y)));
			if (d > despawnRadius) {
				chunks.Remove (chunkpiece);
				chunkLoadedSet.Remove ((int)chunkpiece.transform.position.x + " " + (int)chunkpiece.transform.position.y);
				Destroy (chunkpiece);
			}
		}
	}
}
