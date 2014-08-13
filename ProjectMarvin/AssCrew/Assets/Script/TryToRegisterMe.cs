using UnityEngine;
using System.Collections;

public class TryToRegisterMe : MonoBehaviour {

	public LobbyManager lobby;
	public int NumberOfPlayers;

	void Start(){
		StartCoroutine(CheckLobbyManager());
	}

	// Use this for initialization
	IEnumerator CheckLobbyManager() {
		while(lobby == null){
			GameObject LobbyManager = GameObject.Find("LobbyManager")as GameObject;
			if(LobbyManager!=null){
				lobby = LobbyManager.GetComponent<LobbyManager>();
			}
			yield return new WaitForSeconds(0.5f);
		}
		if(Network.isServer){
			lobby.InitiateLobby(NumberOfPlayers);
			this.gameObject.name = "Player"+(lobby.index+1);
			lobby.RegisterPlayer(this.gameObject.networkView.viewID);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
