using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour {

	public GameObject pauseMenu; 

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();
		}
	}

	public void Pause() {
		if (pauseMenu.activeInHierarchy == false) {
			pauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else {
			pauseMenu.SetActive (false); 
			Time.timeScale = 1;
		}	
	}

	public void LeaveGame() {
		Application.Quit ();
	}

}
