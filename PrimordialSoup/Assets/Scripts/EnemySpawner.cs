using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public List<GameObject> blueTiles;
	public List<GameObject> enemies;
	Object[] sublist;

	public int currentEnemies = 0;
	public int maxEnemies = 15;


	public float period = 0.0f;

	Generator generator;


	// Use this for initialization
	void Start () {
		generator = GetComponent<Generator> ();
		blueTiles = generator.blues;
		sublist = Resources.LoadAll<GameObject> ("NeutralEnemies");

		foreach (GameObject enemy in sublist) 
		{    
			GameObject lo = (GameObject)enemy;

			enemies.Add(lo);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (period > 30) {
			spawnEnemies ();
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
				Instantiate (ene, loc, ene.transform.rotation);
				currentEnemies++;
			}
		}

	}
}
