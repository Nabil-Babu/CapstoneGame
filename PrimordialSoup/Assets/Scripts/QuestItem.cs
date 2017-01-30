﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

	public string Desc;
	public string entity;
	public int quantity;
	public string questType;


	private string[] enemies = new string[] {"enemy1","enemy2","enemy3","enemy4","enemy5","enemy6"};
	private string[] pickupItems = new string[] {"enemyHeart","enemyHeart","enemyHeart"};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateQuest(string type) {
		
		questType = type;

		if (type == "combat") {
			Desc = "Kill";
			// Making a Combat Quest
			entity = enemies [Random.Range (0, enemies.Length)]; //Pick Enemy from array
			quantity = Random.Range (5, 15); 
			Desc = Desc + " " +quantity+ " " +entity; // Create description string 
		} else if (type == "resource") {
			Desc = "Collect";
			// Making a Resource Quest
			entity = pickupItems [Random.Range (0, pickupItems.Length)]; //Pick Enemy from array
			quantity = Random.Range (5, 10); 
			Desc = Desc + " " +quantity+ " " +entity; // Create description string
		}
	}

	public void Death() {
		Destroy (gameObject); 
	}
}
