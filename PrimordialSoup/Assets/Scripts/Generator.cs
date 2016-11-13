using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject dirtPrefab;
	public GameObject grassPrefab;

	public int minX = -11;
	public int maxX = 11;
	public int minZ = -11;
	public int maxZ = 11;
	public int minY = -10;
	public int maxY = 10; 

	PerlinNoise noise;

	// Use this for initialization
	void Start () {
		noise = new PerlinNoise (Random.Range(1000000, 10000000));
		Regenerate();
	}

	private void Regenerate() {
		float width = dirtPrefab.transform.lossyScale.x;
		float height = dirtPrefab.transform.lossyScale.y;
		float depth = dirtPrefab.transform.lossyScale.z;


		for (int i = minX; i < maxX; i++) {
			for (int k = minZ; k < maxZ; k++) {
				int columnHeight = noise.getNoise (i - minX, k - minZ, maxY - minY); //getNoise breaks down if i < 0, so we subtract the minX
				for (int j = minY; j < minY + columnHeight; j++) {
					GameObject block = (j == minY + columnHeight - 1) ? grassPrefab : dirtPrefab;
					Instantiate (block, new Vector3 (i * width, j * height, k * depth), Quaternion.identity);
				}
			}
		}
	}

}
