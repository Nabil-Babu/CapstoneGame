﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour {

	public GameObject meleeSpot;
	public GameObject melee;
	public int meleeDMG = 5; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			Melee ();
		}
			
	}

	void Melee(){
		Instantiate (melee, meleeSpot.transform.position, meleeSpot.transform.rotation);
	}

}
