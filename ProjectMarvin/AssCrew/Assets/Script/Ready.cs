using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour {
	
	public bool ready;
	public PlayerInLobbyMovement scriptMov;
	public int N;
	public LobbyManager lobbyManager;
	
	public GameObject ReadyWord;
	public MeshRenderer render;
	
	// Use this for initialization
	void Start () {
		scriptMov = GetComponent<PlayerInLobbyMovement>();
		//N = scriptMov.Number;
		lobbyManager = GameObject.Find("LobbyManager(Clone)").GetComponent<LobbyManager>();
		lobbyManager.RegisterPlayer(this.gameObject.networkView.viewID);
		render = ReadyWord.GetComponent<MeshRenderer>();
		render.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button2))&&networkView.isMine){
			ready = !ready;
			if(ready){
				lobbyManager.SetPlayerReady(this.gameObject.networkView.viewID);
				render.enabled = true;
			}
			else{
				lobbyManager.SetPlayerReady(this.gameObject.networkView.viewID);
				render.enabled = false;
			}
			//LM.RegistPlayer(N,Ready);
		}
	}
}
