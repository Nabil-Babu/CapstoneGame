using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Dictionary<string,int> inventory;
	PlayerQuests playerQuests;

	// Use this for initialization
	void Start () {
		playerQuests = GetComponent<PlayerQuests> ();
		rb2d = GetComponent<Rigidbody2D> ();
		inventory = new Dictionary<string, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.CompareTag ("item")) {
			Rotator item = other.GetComponent<Rotator>();
			//Add to Inventory
			string itemName = item.gameObject.name.Replace("(Clone)","");
			if (!inventory.ContainsKey (itemName)) {
				inventory.Add (itemName, 1);
			} else {
				int quantity = inventory [itemName];
				quantity++;
				inventory [itemName] = quantity;
			}

			//Check Quests
			playerQuests.CheckCurrentQuests(itemName);

		}

	}
}
