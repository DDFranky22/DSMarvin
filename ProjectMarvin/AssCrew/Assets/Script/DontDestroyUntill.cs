using UnityEngine;
using System.Collections;

public class DontDestroyUntill : MonoBehaviour {

	public string CurrentScene;
	public string PreviousScene;
	public string tempScene;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad(this.gameObject);
		CheckScene();
	}

	void CheckScene(){
		tempScene = Application.loadedLevelName;
		if(tempScene.Equals(CurrentScene)){
			return;
		}
			PreviousScene = CurrentScene;
			CurrentScene = tempScene;
		if((PreviousScene.Equals("LMGameCreation")&&CurrentScene.Equals("MenuTest"))||(PreviousScene.Equals("Options")&&CurrentScene.Equals("MenuTest"))){
			Destroy(this.gameObject);
			return;
		}
		if(CurrentScene.Equals("LMLobby")||CurrentScene.Equals("Instruction")||CurrentScene.Equals("Lobby")){
			Destroy(this.gameObject);
			return;
		}
	}
}
