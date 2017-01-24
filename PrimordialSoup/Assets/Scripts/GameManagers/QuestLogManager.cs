using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogManager : MonoBehaviour {

	public GameObject questLog;
	public Text quest1;
	public Text quest2;
	public Text quest3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) 
		{
			if (questLog.activeInHierarchy == false) {
				questLog.SetActive (true);
				Time.timeScale = 0;
			} else {
				questLog.SetActive (false); 
				Time.timeScale = 1;
			}	
		}
		
	}
}
