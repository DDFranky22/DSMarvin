using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenuBehaviour : MonoBehaviour {

	public int PlayerPause;
	public bool paused;
	public GUIText[] Scritte;


	// Use this for initialization
	void Start () {
		Scritte = GetComponentsInChildren<GUIText>();
		foreach(GUIText scritta in Scritte){
			scritta.enabled = false;
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PauseGame(int x){
		if(paused)
			return;
		PlayerPause = x;
		foreach(GUIText scritta in Scritte){
			scritta.enabled = true;
		}

		paused = true;
		Time.timeScale = 0.0f;
	}

	public void QuitCurrentGame(int x){
		if(x==PlayerPause){
			Time.timeScale = 1.0f;
			GameObject manager = GameObject.Find("GameSettingsManager");
			Destroy(manager);
			Application.LoadLevel("LMGameCreation");
		}
		return;
	}

	public void ResumeGame(int x){
		if(x == PlayerPause){
			foreach(GUIText scritta in Scritte){
				scritta.enabled = false;
			}	

			paused = false;
			Time.timeScale = 1.0f;
		}
	}

}
