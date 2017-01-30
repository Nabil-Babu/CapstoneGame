using UnityEngine;
using System.Collections.Generic;

public class Generator : MonoBehaviour {

	public GameObject stoneTile;
	public GameObject groundTile;
	public GameObject ironTile;
	public GameObject goldTile;
	public GameObject copperTile;
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
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
	public List<GameObject> greens; 
	private Vector2 centerPoint;
	private Vector2 playerSpawn;
	private Vector2 enemySpawn;

	EnemySpawner enemyspawner;
	QuestDropper dropper;
	PerlinNoise noise;

	// Use this for initialization
	void Start () {
		enemyspawner = GetComponent<EnemySpawner> ();
		dropper = GetComponent<QuestDropper> ();
		tileGrid = new GameObject[maxX,maxY];
		noise = new PerlinNoise (Random.Range(1000000, 10000000));
		Regenerate();
		spawnPlayer ();
		enemyspawner.spawnEnemies ();
		dropper.dropQuest (numOfQuests);
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
						GameObject block = (GameObject)Instantiate (copperTile, new Vector2 (i + width, j + height), copperTile.transform.rotation);
						tileGrid [i, j] = block;
					} else {
						GameObject block = (GameObject)Instantiate (stoneTile, new Vector2 (i + width, j + height), stoneTile.transform.rotation);
						tileGrid [i, j] = block;
					}

				}
				else if (zz >= copperThresh && zz < goldThresh){
					int x = Random.Range (0, 100);
					if (x < ironChance) {
						GameObject block = (GameObject)Instantiate (ironTile, new Vector2 (i + width, j + height), ironTile.transform.rotation);
						tileGrid [i, j] = block;
					} else {
						GameObject block = (GameObject)Instantiate (stoneTile, new Vector2 (i + width, j + height), stoneTile.transform.rotation);
						tileGrid [i, j] = block;
					}
				}

				else if(zz >= goldThresh) {
					int x = Random.Range (0, 100);
					if (x < goldChance) {
						GameObject block = (GameObject)Instantiate (goldTile, new Vector2 (i + width, j + height), goldTile.transform.rotation);
						tileGrid [i, j] = block;
					} else {
						GameObject block = (GameObject)Instantiate (stoneTile, new Vector2 (i + width, j + height), stoneTile.transform.rotation);
						tileGrid [i, j] = block;
					}
				}
				else {
					GameObject block = (GameObject) Instantiate (groundTile, new Vector2(i + width, j + height), groundTile.transform.rotation);
					tileGrid [i, j] = block;
					blues.Add (block);
				} 
			}
			 
		}
	}

	private void spawnPlayer() {

		float xPos = 0;
		float yPos = 0;

	
		float cDist = 0; //Current blue tile that is the closest to the center of the map. 

		xPos = (tileGrid [maxX - 1, maxY - 1].transform.position.x - tileGrid [0, 0].transform.position.x) / 2;
		yPos = (tileGrid [maxX - 1, maxY - 1].transform.position.y - tileGrid [0, 0].transform.position.y) / 2;

		centerPoint = new Vector2 (xPos, yPos);

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
