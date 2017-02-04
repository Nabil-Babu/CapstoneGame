using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public GameObject inventoryMenu;
	public PlayerInventory playerInventory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerInventory == null) {
			playerInventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInventory> ();
		} 

		if (Input.GetKeyDown (KeyCode.I)) 
		{
			UpdateInventory ();
			if (inventoryMenu.activeInHierarchy == false) {
				inventoryMenu.SetActive (true);
				Time.timeScale = 0;
			} else {
				inventoryMenu.SetActive (false); 
				Time.timeScale = 1;
			}	
		}
	}

	public void UpdateInventory () {
		int slot = 0;
		foreach (KeyValuePair<string, int> kvp in playerInventory.inventory) 
		{
			Sprite spr = Resources.Load<Sprite>("Art/"+kvp.Key);
			inventoryMenu.transform.GetChild (slot).GetComponent<UnityEngine.UI.Image> ().sprite = spr;
			inventoryMenu.transform.GetChild (slot).transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text = kvp.Value.ToString ();
		}
	}
}
