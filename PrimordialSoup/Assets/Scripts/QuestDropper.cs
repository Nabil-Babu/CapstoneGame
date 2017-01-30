using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDropper : MonoBehaviour {

	public GameObject questPre;

	public List<GameObject> blueTiles;

	Generator generator;

	private Vector3 pos = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {
		generator = GetComponent<Generator> ();
		blueTiles = generator.blues;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void dropQuest(int x) {
		for (int i = 0; i < x; i++) {
			Vector2 pos;
			GameObject tile = blueTiles [Random.Range (0, blueTiles.Count)];
			pos = new Vector2 (tile.transform.position.x, tile.transform.position.y);
			QuestItem quest = questPre.GetComponent<QuestItem> ();
			quest.GenerateQuest ("resource");
			Instantiate (questPre, new Vector2 (pos.x, pos.y), questPre.transform.rotation);
		}

	}
}
