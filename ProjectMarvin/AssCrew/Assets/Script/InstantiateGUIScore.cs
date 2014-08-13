using UnityEngine;
using System.Collections;

public class InstantiateGUIScore : MonoBehaviour {
	public GameObject prefabGUI;
	public LMGameSettings settings;

	// Use this for initialization
	void Start () {
		settings = GameObject.Find("GameSettingsManager").GetComponent<LMGameSettings>();
		for(int i = 1;i<=settings.GetPlayers();i++){
			GameObject temp = Instantiate(prefabGUI) as GameObject;
			LMPlaceScoreInLobby tempscript= temp.GetComponent<LMPlaceScoreInLobby>();
			tempscript.player = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
