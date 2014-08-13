using UnityEngine;
using System.Collections;

public class GUICreationServer : MonoBehaviour {

	public int Players;
	public int NPC;
	public bool Spectator;
	public bool Player;
	public float ModeSX;
	public float ModeSY;
	public float ModeDX;
	public float ModeDY;
	public float ObsSX;
	public float ObsSY;
	public float ObsDX;
	public float ObsDY;
	public float PlaSX;
	public float PlaSY;
	public float PlaDX;
	public float PlaDY;
	public float LaunchSX;
	public float LaunchSY;
	public float LaunchDX;
	public float LaunchDY;

	public float LabelNumbPlayersSX;
	public float LabelNumbPlayersSY;
	public float LabelNumbPlayersDX;
	public float LabelNumbPlayersDY;

	public float NumbPlayersSX;
	public float NumbPlayersSY;
	public float NumbPlayersDX;
	public float NumbPlayersDY;

	public float PlusSX;
	public float PlusSY;
	public float PlusDX;
	public float PlusDY;

	public float MinusSX;
	public float MinusSY;
	public float MinusDX;
	public float MinusDY;

	public float LabelNumbNPCSX;
	public float LabelNumbNPCSY;
	public float LabelNumbNPCDX;
	public float LabelNumbNPCDY;

	public float NumbNPCSX;
	public float NumbNPCSY;
	public float NumbNPCDX;
	public float NumbNPCDY;

	public float PlusNPCSX;
	public float PlusNPCSY;
	public float PlusNPCDX;
	public float PlusNPCDY;

	public float MinusNPCSX;
	public float MinusNPCSY;
	public float MinusNPCDX;
	public float MinusNPCDY;


	private NetworkManager netManager;
	private CheckingStatePlayer check;

	private HostData[] hostList;
	private HostData hostSelected;
	// Use this for initialization
	void Start () {
		ModeSX= 30.0f;
		ModeSY = 30.0f;
		ModeDX = 15.0f;
		ModeDY = 15.0f;
		ObsSX = 10.0f;
		ObsSY = 30.0f;
		ObsDX = 10.0f;
		ObsDY= 15.0f;
		PlaSX = 4.63f;
		PlaSY= 30.0f;
		PlaDX= 10.0f;
		PlaDY= 15.0f;
		LaunchSX= 10.0f;
		LaunchSY= 10.0f;
		LaunchDX= 7.0f;
		LaunchDY= 8.0f;

		LabelNumbPlayersSX = 3.0f;
		LabelNumbPlayersSY = 30.0f;
		LabelNumbPlayersDX = 6.0f;
		LabelNumbPlayersDY = 15.0f;
		
		NumbPlayersSX = 1.9f;
		NumbPlayersSY = 30.0f;
		NumbPlayersDX = 10.0f;
		NumbPlayersDY = 10.0f;
		
		
		PlusSX = 1.7f;
		PlusSY = 30.0f;
		PlusDX = 30.0f;
		PlusDY = 30.0f;
		
		MinusSX = 1.7f;
		MinusSY = 15.0f;
		MinusDX = 30.0f;
		MinusDY = 30.0f;

		LabelNumbNPCSX = 1.52f;
		LabelNumbNPCSY = 30.0f;
		LabelNumbNPCDX = 6.0f;
		LabelNumbNPCDY = 15.0f;
		
		NumbNPCSX = 1.15f;
		NumbNPCSY = 30.0f;
		NumbNPCDX = 10.0f;
		NumbNPCDY = 10.0f;
		
		
		PlusNPCSX = 1.1f;
		PlusNPCSY = 30.0f;
		PlusNPCDX = 30.0f;
		PlusNPCDY = 30.0f;
		
		MinusNPCSX = 1.1f;
		MinusNPCSY = 15.0f;
		MinusNPCDX = 30.0f;
		MinusNPCDY = 30.0f;

		Players = 2;
		NPC = 15;

		netManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		check = GameObject.Find("NetworkManager").GetComponent<CheckingStatePlayer>();
		hostList = netManager.getHostList();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		GUI.contentColor = Color.black;

		GUI.Label(new Rect(Screen.width/ModeSX,Screen.height/ModeSY,Screen.width/ModeDX,Screen.height/ModeDY),"Mode");
		if(GUI.Toggle(new Rect(Screen.width/ObsSX,Screen.height/ObsSY,Screen.width/ObsDX,Screen.height/ObsDY),Spectator,"Spectator")){
			Spectator = true;
			Player = false;
		}
		if(GUI.Toggle(new Rect(Screen.width/PlaSX,Screen.height/PlaSY,Screen.width/PlaDX,Screen.height/PlaDY),Player,"Player")){
			Player = true;
			Spectator = false;
		}

	if(netManager.AmIServer){

			GUI.Label(new Rect(Screen.width/LabelNumbPlayersSX,Screen.height/LabelNumbPlayersSY,Screen.width/LabelNumbPlayersDX,Screen.height/LabelNumbPlayersDY),"Number of Players");
			GUI.Label(new Rect(Screen.width/NumbPlayersSX,Screen.height/NumbPlayersSY,Screen.width/NumbPlayersDX,Screen.height/NumbPlayersDY),Players+"");
			if(GUI.Button(new Rect(Screen.width/PlusSX,Screen.height/PlusSY,Screen.width/PlusDX,Screen.height/PlusDY),"+")){
				if(Players<8){
					Players++;
				}
			}
			if(GUI.Button(new Rect(Screen.width/MinusSX,Screen.height/MinusSY,Screen.width/MinusDX,Screen.height/MinusDY),"-")){
				if(Players>2){
					Players--;
				}
			}

			GUI.Label(new Rect(Screen.width/LabelNumbNPCSX,Screen.height/LabelNumbNPCSY,Screen.width/LabelNumbNPCDX,Screen.height/LabelNumbNPCDY),"Number of NPC");
			GUI.Label(new Rect(Screen.width/NumbNPCSX,Screen.height/NumbNPCSY,Screen.width/NumbNPCDX,Screen.height/NumbNPCDY),NPC+"");
			if(GUI.Button(new Rect(Screen.width/PlusNPCSX,Screen.height/PlusNPCSY,Screen.width/PlusNPCDX,Screen.height/PlusNPCDY),"+")){
				if(NPC<100){
					NPC++;
				}
			}
			if(GUI.Button(new Rect(Screen.width/MinusNPCSX,Screen.height/MinusNPCSY,Screen.width/MinusNPCDX,Screen.height/MinusNPCDY),"-")){
				if(NPC>1){
					NPC--;
				}
			}

			if(GUI.Button(new Rect(Screen.width/LaunchSX,Screen.height/LaunchSY,Screen.width/LaunchDX,Screen.height/LaunchDY),"Launch Server")){
				check.Player = Player;
				check.Observer = Spectator;
				if(check.Player){
					/*GameObject Plr = new GameObject();
					TryToRegisterMe script = Plr.AddComponent<TryToRegisterMe>();
					script.NumberOfPlayers = 2;
					Plr.AddComponent<NetworkView>();
					Network.Instantiate(Plr,this.transform.position,Quaternion.identity,0);*/
					//DontDestroyOnLoad(Plr);
				}
				netManager.setPlayersNumber(Players);
				netManager.setNpcNumber(NPC);
				netManager.StartServer();
			}
		}
		else{
			if(hostList!=null)
			if(GUI.Button(new Rect(Screen.width/LaunchSX,Screen.height/LaunchSY,Screen.width/LaunchDX,Screen.height/LaunchDY),"Connect Server")){
				print("Hai premuto il pulsante");
				check.Player = Player;
				check.Observer = Spectator;
				netManager.SetConnected(true);
				if(check.Player){
					/*GameObject Plr = new GameObject();
					Plr.AddComponent<TryToRegisterMe>();
					Plr.AddComponent<NetworkView>();
					Network.Instantiate(Plr,this.transform.position,Quaternion.identity,0);*/
					//DontDestroyOnLoad(Plr);
				}
				Application.LoadLevel("Lobby");
			}
			if (hostList != null)
			{
				//print("ho aggiornato la lista");
				print (hostList.Length);
				for (int i = 0; i < hostList.Length; i++)
				{
					//if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName)){
						//JoinServer(hostList[i]);
						netManager.SetHost(hostList[i]);
						//Application.LoadLevel(LevelName);
					//}
				}
			}
			else{
				//print ("Sto aggiornando la lista");
				netManager.RefreshHostList();
				HostData[] temp = netManager.getHostList();
				if(temp!=null)	
				if(temp.Length>0){
					hostList = temp;
				}
				else
					hostList = null;
			}
		}
	}
}
