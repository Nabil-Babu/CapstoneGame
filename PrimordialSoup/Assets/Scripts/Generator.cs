using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject tilePrefab;

	public int minX = -11;
	public int maxX = 11;
	public int minY = -10;
	public int maxY = 10; 

	public int waterLevel = 50; 

	PerlinNoise noise;

	// Use this for initialization
	void Start () {
		noise = new PerlinNoise (Random.Range(1000000, 10000000));
		Regenerate();
	}

	private void Regenerate() {
		float width = tilePrefab.transform.lossyScale.x;
		float height = tilePrefab.transform.lossyScale.y;


		for (int i = minX; i < maxX; i++) {
			for (int j = minY; j < maxY; j++) {
				int zz = noise.getNoise (i - minX, j - minY, 100); //getNoise breaks down if i < 0, so we subtract the minX
				GameObject block = (GameObject) Instantiate (tilePrefab, new Vector2(i + width, j + height), tilePrefab.transform.rotation);
				if (zz < waterLevel) {
					float shade = 0;
					shade = 1 - ((float) zz / (float) waterLevel);
					block.GetComponent<TileChanger>().Color (0, 0, shade);	
				} else {
					float shade = 0;
					shade = 1 - (((float) zz - (float)waterLevel)/ (float) waterLevel);
					block.GetComponent<TileChanger>().Color (0, shade, 0);	
				}
				 
			}
		}
	}
}
