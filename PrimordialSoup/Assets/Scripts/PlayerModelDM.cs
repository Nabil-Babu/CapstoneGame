using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayerModel : MonoBehaviour {

	public Dictionary<string, int> kills = new Dictionary<string, int> ();
	public Dictionary<string, int> item = new Dictionary<string, int> ();
	public Dictionary<string, int> tile = new Dictionary<string, int> ();
	public Dictionary<string, int> questsComp = new Dictionary<string, int> ();
	public Dictionary<string, int> death = new Dictionary<string, int> ();
	public Dictionary<string, int> dmgTaken = new Dictionary<string, int> ();
	public Dictionary<string, int> questsCol = new Dictionary<string, int> ();

	public string path = "C:\\Users\\Derek\\Desktop\\PlayerProfile.txt";

	string  fileName = "PlayerProfile.txt";
	StreamWriter sr;

	// Use this for initialization
	void Start () {

		if (File.Exists (fileName)) {
			Debug.Log (fileName + " already exists.");
			return;
		} else {
			sr = File.CreateText(fileName);
		}
//		sr.WriteLine ("This is my file.");
//		sr.WriteLine ("I can write ints {0} or floats {1}, and so on.",
//			1, 4.2);
//		sr.Close();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addKill(string name){
		if (!kills.ContainsKey (name)) {
			kills.Add (name, 1);
		} else {
			int x = kills [name];
			x++;
			kills [name] = x;
			Debug.Log ("# Kills: " + name + " " + kills[name]);
			writeToModel ("Kills:" + name + ":" + kills [name] + "\r\n");
		}
	}

	public void addQuestComp(string name){
		if (!questsComp.ContainsKey (name)) {
			questsComp.Add (name, 1);
		} else {
			int x = questsComp [name];
			x++;
			questsComp [name] = x;
			Debug.Log(questsComp[name]);
		}
	}

	public void addQuestCol(string name){
		if (!questsCol.ContainsKey (name)) {
			questsCol.Add (name, 1);
		} else {
			int x = questsCol [name];
			x++;
			questsCol [name] = x;
			Debug.Log("# Quests Collected: " + name + " " + questsCol[name]);
			writeToModel ("QuestsCol:" + name + ":" + questsCol[name] + "\r\n");
		}
	}

	public void addTile(string name) {
		if (!tile.ContainsKey (name)) {
			tile.Add (name, 1);
		} else {
			int x = tile [name];
			x++;
			tile [name] = x;
			Debug.Log("# Tiles Destroyed: " + name + " " + tile[name]);
			writeToModel ("Tiles:" + name + ":" + tile[name] + "\r\n");
		}
	}

	public void addItem(string name) {
		if (!item.ContainsKey (name)) {
			item.Add (name, 1);
		} else {
			int x = item [name];
			x++;
			item [name] = x;
			Debug.Log("# Items Collected: " + name + " " + item[name]);
			writeToModel ("Items: " + name + ":" + item[name] + "\r\n");
		}
	}

	public void addDeath(string name) {
		if (!death.ContainsKey (name)) {
			death.Add (name, 1);
		} else {
			int x = death [name];
			x++;
			death [name] = x;
			Debug.Log("# Deaths: " + name + " " + death[name]);
			writeToModel ("Deaths: " + name + ":" + death[name] + "\r\n");
		}
	}

	public void addDamageTaken(string name, int dmg) {
		if (!dmgTaken.ContainsKey (name)) {
			dmgTaken.Add (name, dmg);
		} else {
			int x = dmgTaken [name];
			x = x + dmg;
			dmgTaken [name] = x;
			Debug.Log("Damage Taken: " + name + " " + dmgTaken[name]);
			writeToModel ("Dmg: " + name + ":" + dmgTaken[name] + "\r\n");
		}
	}

	private void writeToModel(string content) {
		File.AppendAllText (path,content);
	}
}
