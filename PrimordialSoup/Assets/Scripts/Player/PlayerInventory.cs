using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Dictionary<string,int> inventory;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		inventory = new Dictionary<string, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.CompareTag ("item")) {
			Rotator item = other.GetComponent<Rotator>();
			string itemName = item.gameObject.name.Replace("(Clone)","");
			if (!inventory.ContainsKey (itemName)) {
				inventory.Add (itemName, 1);
			} else {
				int quantity = inventory [itemName];
				quantity++;
				inventory [itemName] = quantity;
			}

		}

	}
}
