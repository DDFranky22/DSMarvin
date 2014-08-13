using UnityEngine;
using System.Collections;

public class LMPlaceScoreInLobby : MonoBehaviour {

	public LMGameSettings settings;
	public GUIText scriptText;
	public int player;
	// Use this for initialization
	void Start () {
		settings = GameObject.Find("GameSettingsManager").GetComponent<LMGameSettings>();
		scriptText = GetComponent<GUIText>();
		switch(player){
		case 1: 
			if(settings.GetTeam()){
				scriptText.color = Color.blue;
			}
			this.transform.position = new Vector3(0.01f,0.81f);
			break;
		case 2:
			if(settings.GetTeam()){
				scriptText.color = Color.red;
			}
			this.transform.position = new Vector3(0.01f,0.75f);
			break;
		case 3:
			if(settings.GetTeam()){
				scriptText.color = Color.green;
			}
			this.transform.position = new Vector3(0.01f,0.69f);
			break;
		case 4:
			if(settings.GetTeam()){
				scriptText.color = Color.black;
			}
			this.transform.position = new Vector3(0.01f,0.63f);
			break;
		default:
			break;
		}
	}

	void ChangeText(){
		scriptText.text = "Player "+player+": "+settings.GivePlayerWin(player);
	}


	// Update is called once per frame
	void Update () {
		ChangeText();
	}
}
