﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerate : MonoBehaviour {


	public GameObject stoneTile;
	public GameObject groundTile;
	public GameObject ironTile;
	public GameObject goldTile;
	public GameObject copperTile;
	public GameObject[,] tileGrid; 

	public int maxX;
	public int maxY; 
	public int groundLevel;
	public int copperThresh;
	public int goldThresh;
	public int numOfQuests;

	public int copperChance;
	public int ironChance;
	public int goldChance;

	public List<GameObject> blues;

	private float xPos;
	private float yPos;

	EnemySpawner enemyspawner;
	QuestDropper dropper;
	PerlinNoise noise;
	ChunkGenerator chunkGenerator;


	// Use this for initialization
	void Start () {
		xPos = gameObject.transform.position.x;
		yPos = gameObject.transform.position.y;
		enemyspawner = GetComponent<EnemySpawner> ();
		dropper = GetComponent<QuestDropper> ();
		tileGrid = new GameObject[maxX,maxY];
		noise = new PerlinNoise (Random.Range(1000000, 10000000));
		Regenerate();
		if (blues.Count != 0) {
			enemyspawner.spawnEnemies ();
			int i = Random.Range (0, 100);
			if (i < 50) {
				dropper.dropQuest (numOfQuests);
			}

		}

	}

	// Update is called once per frame
	void Update () {

	}

	private void Regenerate() {
		float width = groundTile.transform.lossyScale.x;
		float height = groundTile.transform.lossyScale.y;


		for (int i = 0; i < maxX; i++) {

			for (int j = 0; j < maxY; j++) {
				int zz = noise.getNoise (i, j, 100);
				if (zz >= groundLevel && zz < copperThresh) {
					int x = Random.Range (0, 100);
					if (x < copperChance) {
						GameObject block = (GameObject)Instantiate (copperTile, new Vector2 (i + width + xPos, j + height + yPos), copperTile.transform.rotation);
						block.transform.parent = gameObject.transform;
						tileGrid [i, j] = block;
					} else {
						GameObject block = (GameObject)Instantiate (stoneTile, new Vector2 (i + width + xPos, j + height + yPos), stoneTile.transform.rotation);
						block.transform.parent = gameObject.transform;
						tileGrid [i, j] = block;
					}

				}
				else if (zz >= copperThresh && zz < goldThresh){
					int x = Random.Range (0, 100);
					if (x < ironChance) {
						GameObject block = (GameObject)Instantiate (ironTile, new Vector2 (i + width + xPos, j + height + yPos), ironTile.transform.rotation);
						block.transform.parent = gameObject.transform;
						tileGrid [i, j] = block;
					} else {
						GameObject block = (GameObject)Instantiate (stoneTile, new Vector2 (i + width + xPos, j + height + yPos), stoneTile.transform.rotation);
						block.transform.parent = gameObject.transform;
						tileGrid [i, j] = block;
					}
				}

				else if(zz >= goldThresh) {
					int x = Random.Range (0, 100);
					if (x < goldChance) {
						GameObject block = (GameObject)Instantiate (goldTile, new Vector2 (i + width + xPos, j + height + yPos), goldTile.transform.rotation);
						block.transform.parent = gameObject.transform;
						tileGrid [i, j] = block;
					} else {
						GameObject block = (GameObject)Instantiate (stoneTile, new Vector2 (i + width + xPos, j + height + yPos), stoneTile.transform.rotation);
						block.transform.parent = gameObject.transform;
						tileGrid [i, j] = block;
					}
				}
				else {
					GameObject block = (GameObject) Instantiate (groundTile, new Vector2 (i + width + xPos, j + height + yPos), groundTile.transform.rotation);
					blues.Add (block);
					block.transform.parent = gameObject.transform;
					tileGrid [i, j] = block;

				} 
			}

		}

	}

}
