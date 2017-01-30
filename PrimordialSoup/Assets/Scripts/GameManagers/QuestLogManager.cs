using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogManager : MonoBehaviour {

	public GameObject questLog;
	public PlayerQuests playerQuests;

	public Text quest1;
	public Text quest2;
	public Text quest3;
	public Text reqs1;
	public Text reqs2;
	public Text reqs3;
	public Button button1;
	public Button button2;
	public Button button3;

	private Text[] questsUI = new Text[3];
	private Text[] reqsUI = new Text[3];


	// Use this for initialization
	void Start () {
		questsUI [0] = quest1;
		questsUI [1] = quest2;
		questsUI [2] = quest3;
		playerQuests = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerQuests> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (playerQuests == null) {
			playerQuests = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerQuests> ();
		}

		if (playerQuests.currentQuests > 0) {
			for (int i = 0; i < 3; i++) {
				if (playerQuests.desc [i] != "empty") {
					questsUI [i].text = playerQuests.desc [i];
				}
			}
		}



		if (Input.GetKeyDown (KeyCode.J)) 
		{
			UpdateReqs ();
			if (questLog.activeInHierarchy == false) {
				questLog.SetActive (true);
				Time.timeScale = 0;
			} else {
				questLog.SetActive (false); 
				Time.timeScale = 1;
			}	
		}
		
	}

	void UpdateReqs() {
		if (playerQuests.q1curr.Count > 0) {
			foreach (KeyValuePair<string, int> kvp in playerQuests.q1curr) {
				reqs1.text = kvp.Value + " " + kvp.Key + " remaining";
			}
		} else {
			questsUI [0].text = "";
			reqs1.text = "";
		}
		if (playerQuests.q2curr.Count > 0) {
			foreach (KeyValuePair<string, int> kvp in playerQuests.q2curr) 
			{
				reqs2.text = kvp.Value + " " + kvp.Key+" remaining";
			}
		} else {
			questsUI [1].text = "";
			reqs2.text = "";
		}

		if (playerQuests.q3curr.Count > 0) {
			foreach (KeyValuePair<string, int> kvp in playerQuests.q3curr) 
			{
				reqs3.text = kvp.Value + " " + kvp.Key+" remaining";
			}
		} else {
			questsUI [2].text = "";
			reqs3.text = "";
		}
	}

	public void clearQuest(int x){
		if (x == 0) {
			questsUI [x].text = "";
			playerQuests.desc [x] = "empty";
			playerQuests.clearDictionary (x);
			reqs1.text = "";
			playerQuests.currentQuests--;
		} else if (x == 1) {
			questsUI [x].text = "";
			playerQuests.desc [x] = "empty";
			playerQuests.clearDictionary (x);
			reqs2.text = "";
			playerQuests.currentQuests--;
		} else if (x == 2) {
			questsUI [x].text = "";
			playerQuests.desc [x] = "empty";
			playerQuests.clearDictionary (x);
			reqs3.text = "";
			playerQuests.currentQuests--;
		}

		if (playerQuests.currentQuests < 0) {
			playerQuests.currentQuests = 0;
		}
	}
}
