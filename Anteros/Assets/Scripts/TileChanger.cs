﻿using UnityEngine;
using System.Collections;

public class TileChanger : MonoBehaviour {

	public Color tileColor;
	private MeshRenderer rend; 

	void Start () {
		rend = GetComponent<MeshRenderer>();
	}


	void Update () {
		rend.material.color = tileColor;
	}

	public void Color(float r, float g, float b) {
		tileColor.r = r;
		tileColor.g = g;
		tileColor.b = b;
	}
}
