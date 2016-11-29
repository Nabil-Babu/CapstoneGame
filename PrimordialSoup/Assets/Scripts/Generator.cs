using UnityEngine;
using System.Collections.Generic;

public class Generator : MonoBehaviour {

	public GameObject greenTile;
	public GameObject blueTile;
	public GameObject redTile;
	public GameObject yellowTile;
	public GameObject playerPrefab;

	public int maxX;
	public int maxY; 
	public int waterLevel;
	public List<GameObject> blues;
	public List<GameObject> greens; 
	public GameObject[,] tileGrid; 

	private Vector2 centerPoint;
	private Vector2 playerSpawn;

	private int greenMax = 0;
	private int redMax = 0;
	PerlinNoise noise;

	// Use this for initialization
	void Start () {
		//greenMax = waterLevel + (100 - waterLevel) / 2;
		//redMax = greenMax + (100 - greenMax) / 2;
		greenMax = 60;
		redMax = 72;
		tileGrid = new GameObject[maxX,maxY];
		noise = new PerlinNoise (Random.Range(1000000, 10000000));
		Regenerate();
		spawnPlayer ();
	}

	private void Regenerate() {
		float width = blueTile.transform.lossyScale.x;
		float height = blueTile.transform.lossyScale.y;


		for (int i = 0; i < maxX; i++) {
			 
			for (int j = 0; j < maxY; j++) {
				int zz = noise.getNoise (i, j, 100);
				//Debug.Log (zz);
				if (zz >= waterLevel && zz < greenMax) {
					GameObject block = (GameObject)Instantiate (greenTile, new Vector2 (i + width, j + height), greenTile.transform.rotation);
					tileGrid [i, j] = block;
					greens.Add (block);
				}
				else if (zz >= greenMax && zz < redMax){
					GameObject block = (GameObject)Instantiate (redTile, new Vector2 (i + width, j + height), redTile.transform.rotation);
					tileGrid [i, j] = block;
				}

				else if(zz >= redMax) {
					GameObject block = (GameObject)Instantiate (yellowTile, new Vector2 (i + width, j + height), yellowTile.transform.rotation);
					tileGrid [i, j] = block;
				}

				else {
					GameObject block = (GameObject) Instantiate (blueTile, new Vector2(i + width, j + height), blueTile.transform.rotation);
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
