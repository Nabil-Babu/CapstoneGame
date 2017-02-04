using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour {

	public GameObject meleeSpot;
	public GameObject melee;
	public int meleeDMG = 5; 

	public AudioClip drillSound;

	private AudioSource source;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			Melee ();
		}
			
	}

	void Melee(){
		source.PlayOneShot(drillSound,1);
		Instantiate (melee, meleeSpot.transform.position, meleeSpot.transform.rotation);
	}

}
