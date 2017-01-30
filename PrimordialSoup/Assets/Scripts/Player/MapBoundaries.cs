using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundaries : MonoBehaviour {

	Generator generator;

	public Vector2 min, max;

	Vector2 pos; 

	// Use this for initialization
	void Start () {
		generator = GameObject.FindGameObjectWithTag ("Generator").GetComponent<Generator> ();
		min = generator.tileGrid [0, 0].transform.position;
		max = generator.tileGrid [generator.maxX-1, generator.maxY-1].transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		pos = gameObject.transform.position;

		if (generator == null) {
			Debug.Log ("Got here");
			generator = GameObject.FindGameObjectWithTag ("Generator").GetComponent<Generator> ();
			min = generator.tileGrid [0, 0].transform.position;
			max = generator.tileGrid [generator.maxX-1, generator.maxY-1].transform.position;
		}



		if (pos.x > max.x) {
			pos.x = max.x;

		} else if (pos.y > max.y) {
			pos.y = max.y;

		} else if (pos.x < min.x) {
			pos.x = min.x;

		} else if(pos.y < min.y) {
			pos.y = min.y;

		}

		gameObject.transform.position = pos;
	}
}
