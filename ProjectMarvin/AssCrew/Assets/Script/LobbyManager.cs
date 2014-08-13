using UnityEngine;
using System.Collections;

public class LobbyManager : MonoBehaviour {
	
	public int NumberOfPlayer;
	public NetworkViewID[] Players;
	public bool[] PlayerReady;
	public int index;
	public NetworkManager netManager;
	public GUIText TextScript;

	public bool check;


	public GUIText scriptGUI;
	public GameObject ReadyObject;
	private GameObject Player2Ready;

	void Start(){
		netManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		if(Network.isServer){
			InitiateLobby(netManager.getPlayersNumber());
			StartCoroutine(CheckForStart());
		}
		TextScript = GameObject.Find("TestMulti(Clone)").GetComponent<GUIText>();
		TextScript.text = "Players: "+(Network.connections.Length+1)+"/"+netManager.getPlayersNumber();
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		GameObject giocatore = null;
		for(int i = 0;i<players.Length;i++)
			if(players[i].gameObject.networkView.isMine){
				giocatore = players[i];
			break;
			}
	}

	public void InitiateLobby(int n){
		index = 0;
		NumberOfPlayer = n;
		PlayerReady = new bool[n];
		Players = new NetworkViewID[n];
	}

	void OnPlayerConnected(NetworkPlayer player) {

		networkView.RPC("InstantiatePlayer",player,null);
		networkView.RPC("SyncNumber",RPCMode.AllBuffered,NumberOfPlayer);
		TextScript.text = "Players: "+(Network.connections.Length+1)+"/"+netManager.getPlayersNumber();
		/*
		networkView.RPC("SyncPlayerReady",RPCMode.AllBuffered,PlayerReady);
		networkView.RPC("SyncPlayers",RPCMode.AllBuffered,Players);
		networkView.RPC("SyncIndex",RPCMode.AllBuffered,index);
		*/
	}

	void OnPlayerDisconnected(NetworkPlayer player){
		TextScript.text = "Players: "+(Network.connections.Length+1)+"/"+netManager.getPlayersNumber();
	}

	public void Update(){
		DontDestroyOnLoad(this.gameObject);
	}

	public void RegisterPlayer(NetworkViewID p){
		if(Network.isServer){
			Players[index] = p;
			index++;
		}
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		bool[] sup = new bool[NumberOfPlayer];
		for(int i = 0;i<NumberOfPlayer;i++){
			if (stream.isWriting) {
				sup[i] = PlayerReady[i];
				stream.Serialize(ref sup[i]);
			} else {
				stream.Serialize(ref sup[i]);
				PlayerReady[i] = sup[i];
			}
		}
	}

	public void SetPlayerReady(NetworkViewID p){
		if(Network.isServer){
			int ind = FindPlayerIndex(p);
			PlayerReady[ind] = !PlayerReady[ind];
			if(PlayerReady[ind])
				networkView.RPC("SetTextActive",RPCMode.All,1);
			else
				networkView.RPC("SetTextOff",RPCMode.All,1);
		}
		if(Network.isClient){
			networkView.RPC("SetMeReady",RPCMode.Server,p);
		}
	}

	public int FindPlayerIndex(NetworkViewID p){
		for(int i = 0;i<Players.Length;i++){
			if(p.Equals(Players[i]))
				return i;
		}
		return -1;
	}

	IEnumerator CheckForStart(){
		while(!check){
			int ok = 0;
			for(int i = 0;i<Players.Length;i++){
				if(PlayerReady[i]){
					ok++;
				}
			}
				if(ok>=PlayerReady.Length){
					networkView.RPC("LoadNextLevel",RPCMode.Others,0);
					check = true;
					Application.LoadLevel("TestProspective");
				}
			yield return new WaitForSeconds(0.5f);
		}
	}

	[RPC]
	void LoadNextLevel(int a){
		Application.LoadLevel("TestProspective");
	}

	[RPC]
	void InstantiatePlayer(){
		CreatePlayerInLobby cpil = Camera.main.GetComponent<CreatePlayerInLobby>();
		cpil.Instantiate();
	}
	
	
	[RPC]
	void SyncNumber(int n){
		NumberOfPlayer = n;
		PlayerReady = new bool[n];
	}
	
	[RPC]
	void SyncPlayers(NetworkViewID[] p){
		Players = p;
	}
	
	[RPC]
	void SyncPlayerReady(bool[] r){
		PlayerReady = r;
	}
	
	[RPC]
	void SyncIndex (int i){
		index = i;
	}
	
	
	[RPC]
	void SetMeReady(NetworkViewID p){
		int ind = FindPlayerIndex(p);
		PlayerReady[ind] = !PlayerReady[ind];
		if(PlayerReady[ind]){
			networkView.RPC("SetTextActive",RPCMode.All,2);
		}
		else{
			networkView.RPC("SetTextOff",RPCMode.All,2);
		}
	}

	[RPC]
	void SetTextActive(int idPlayer){
		GameObject text = ReadyObject;
		MeshRenderer txtmesh = text.GetComponent<MeshRenderer>();
		txtmesh.enabled = true;
	}

	[RPC]
	void SetTextOff(int idPlayer){
		GameObject text = null;
		if(idPlayer == 1){
			text = ReadyObject;
		}
		else{
			text = ReadyObject;
		}
		MeshRenderer txtmesh = text.GetComponent<MeshRenderer>();
		txtmesh.enabled = true;
	}

}
