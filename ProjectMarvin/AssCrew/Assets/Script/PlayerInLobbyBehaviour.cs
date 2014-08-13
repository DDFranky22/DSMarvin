using UnityEngine;
using System.Collections;

public class PlayerInLobbyBehaviour : MonoBehaviour {

	public LobbyManager lobbyManager;

	// Use this for initialization
	void Start () {
		lobbyManager = GameObject.Find("LobbyManager(Clone)").GetComponent<LobbyManager>();
		lobbyManager.RegisterPlayer(this.gameObject.networkView.viewID);
	}

	IEnumerator CheckForLobbyManager(){
		while(lobbyManager==null){
			GameObject temp = GameObject.Find("LobbyManager(Clone)");
			if(temp!=null){
				lobbyManager = temp.GetComponent<LobbyManager>();
				lobbyManager.RegisterPlayer(this.gameObject.networkView.viewID);
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			if(networkView.isMine){
				lobbyManager.SetPlayerReady(this.gameObject.networkView.viewID);
			}
		}
	}
}
