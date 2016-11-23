using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject tilePrefab;
	public GameObject playerPrefab;

	public int maxX;
	public int maxY; 
	public int waterLevel;
	public GameObject[,] tileGrid;

	private Vector2 playerSpawn;

	PerlinNoise noise;

	// Use this for initialization
	void Start () {
		tileGrid = new GameObject[maxX,maxY];
		noise = new PerlinNoise (Random.Range(1000000, 10000000));
		Regenerate();
		spawnPlayer ();
	}

	private void Regenerate() {
		float width = tilePrefab.transform.lossyScale.x;
		float height = tilePrefab.transform.lossyScale.y;


		for (int i = 0; i < maxX; i++) {
			 
			for (int j = 0; j < maxY; j++) {
				int zz = noise.getNoise (i, j, 100);
				GameObject block = (GameObject) Instantiate (tilePrefab, new Vector2(i + width, j + height), tilePrefab.transform.rotation);
				tileGrid [i, j] = block;
				if (zz >= waterLevel) {
					block.GetComponent<TileChanger>().Color (0, 255, 0);	
				} else {
					block.GetComponent<TileChanger>().Color (0, 0, 255);
				} 
			}
			 
		}
	}

	private void spawnPlayer() {

		float xPos = 0;
		float yPos = 0;

		xPos = (tileGrid [maxX - 1, maxY - 1].transform.position.x - tileGrid [0, 0].transform.position.x) / 2;
		yPos = (tileGrid [maxX - 1, maxY - 1].transform.position.y - tileGrid [0, 0].transform.position.y) / 2;

		playerSpawn = new Vector2 (xPos, yPos);

		Instantiate (playerPrefab, playerSpawn, playerPrefab.transform.rotation);


	}
}
