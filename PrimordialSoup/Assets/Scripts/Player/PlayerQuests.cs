using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerQuests : MonoBehaviour {

	private Rigidbody2D rb2d;
	public int currentQuests = 0;
	public string[] desc;

	int q1req;
	int q2req;
	int q3req;

	public Dictionary<string, int> q1curr = new Dictionary<string, int>();
	public Dictionary<string, int> q2curr = new Dictionary<string, int> ();
	public Dictionary<string, int> q3curr = new Dictionary<string, int> ();


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		desc = new string[] {"empty","empty","empty"};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.CompareTag ("quest")) {
			if (currentQuests < 3) {
				QuestItem quest = other.GetComponent<QuestItem> ();
				AddQuest (quest);
				currentQuests++;
				quest.Death ();
			} else {
				Debug.Log ("Quest Log is full");
			}

		}

	}

	void AddQuest(QuestItem quest){

		for (int i = 0; i < 3; i++) {
			if (desc [i] == "empty") {
				desc [i] = quest.Desc;
				UpdateDictionary (i, quest);
				return;
			}
		}
	}

	void UpdateDictionary(int x, QuestItem quest){
		if (x == 0) {
			q1curr.Add (quest.entity, quest.quantity);
			q1req = quest.quantity;
		} else if (x == 1) {
			q2curr.Add (quest.entity, quest.quantity);
			q2req = quest.quantity;
		} else if (x == 2) {
			q3curr.Add (quest.entity, quest.quantity);
			q3req = quest.quantity;
		}
	}

	public void clearDictionary(int x){
		if (x == 0) {
			q1curr.Clear ();
		} else if (x == 1) {
			q2curr.Clear ();
		} else if (x == 2) {
			q3curr.Clear ();
		}
	}

	public void CheckCurrentQuests(string entity) {
		if(q1curr.ContainsKey(entity)){
			q1curr [entity]--;
			if (q1curr [entity] <= 0) {
				Debug.Log ("Quest Complete");
				desc [0] = "empty";
				q1curr.Clear ();
				currentQuests--;
			}
		}

		if(q2curr.ContainsKey(entity)){
			q2curr [entity]--;
			if (q2curr [entity] <= 0) {
				Debug.Log ("Quest Complete");
				desc [1] = "empty";
				q2curr.Clear ();
				currentQuests--;
			}
		}

		if(q3curr.ContainsKey(entity)){
			q3curr [entity]--;
			if (q3curr [entity] <= 0) {
				Debug.Log ("Quest Complete");
				desc [2] = "empty";
				q3curr.Clear ();
				currentQuests--;
			}
		}
	}
}
