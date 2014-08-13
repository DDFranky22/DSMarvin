using UnityEngine;
using System.Collections;
using System.Net;

public class NetworkManager : MonoBehaviour {

	private const string typeName = "GameName";
	private const string gameName = "RoomName";
	private HostData[] hostList;
	private HostData host;
	private bool ClientConnected;

	public GameObject playerPrefab;

	public string LevelName;

	private bool PlayerSpectator;

	public bool AmIServer;

	private int NumberOfPlayer;
	private int NumberOfNPC;

	void Start(){
		PlayerSpectator = true;
		NumberOfNPC = 30;
		NumberOfPlayer = 2;
		//MasterServer.ipAddress = "127.0.0.1";
	}

	public void StartServer(){
		Network.InitializeServer(4,25000, !Network.HavePublicAddress());
		/*typeName = "GameName\\GameMode";
		IPHostEntry IPHost = Dns.GetHostEntry(Dns.GetHostName());
		gameName = IPHost.AddressList[0].ToString();
		print (typeName+": "+gameName);*/
		MasterServer.RegisterHost(typeName,gameName);
	}

	void OnServerInitialized(){
		Debug.Log("Server Started");
		Application.LoadLevel(LevelName);
		//SpawnPlayer();
	}

	public void RefreshHostList(){
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent){
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}

	public void JoinServer(HostData hostData){
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer(){
		Debug.Log("Server Joined");
	}
	
	public HostData[] getHostList(){
		return hostList;
	}

	public void SetConnected(bool v){
		ClientConnected = v;
	}

	public void SetHost(HostData h){
		host = h;
	}

	public void setNpcNumber(int x){
		NumberOfNPC = x;
	}

	public int getNpcNumber(){
		return NumberOfNPC;
	}

	public void setPlayersNumber(int x){
		NumberOfPlayer = x;
	}

	public int getPlayersNumber(){
		return NumberOfPlayer;
	}

	public void setPlayerSpectator(bool v){
		PlayerSpectator = v;
	}

	public bool getPlayerSpectator(){
		return PlayerSpectator;
	}

	void Update(){
		if(ClientConnected){
			JoinServer(host);
			ClientConnected = false;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
