
using UnityEngine;
using System.Collections;

public class CreatePlayerInLobby : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject LobbyManager;
	public GameObject Text;
	//public GameObject PlayerReady;
	public GameObject Player2Ready;

	public GameObject PlayerModel;

	void Start(){
		Instantiate();
	}

	// Use this for initialization
	public void Instantiate() {
		/*if(Network.isServer){
			Network.Instantiate(LobbyManager,this.transform.position,Quaternion.identity,0);
			GameObject p = Network.Instantiate(playerPrefab,this.transform.position,Quaternion.identity,0) as GameObject;
			p.name = "Player1";
			Network.Instantiate(Player1Ready,Player1Ready.transform.position,Quaternion.identity,0);
			Network.Instantiate(Player2Ready,Player2Ready.transform.position,Quaternion.identity,0);
		}
		if(Network.isClient){
			GameObject p = Network.Instantiate(playerPrefab,this.transform.position,Quaternion.identity,0) as GameObject;
			p.name = "Player2";
		}*/
		if(true){
			Vector3 position = new Vector3(Random.Range(-9,9),0.0f,Random.Range(-8,8));
			if(Network.isServer){
				Network.Instantiate(Text,Text.transform.position,Quaternion.identity,0);
				Network.Instantiate(LobbyManager,position,Quaternion.identity,0);
			}
			GameObject p = Network.Instantiate(playerPrefab,position,Quaternion.identity,0) as GameObject;
			p.name = "Player1";
			GameObject playermodel = Network.Instantiate(PlayerModel,position,Quaternion.identity,0) as GameObject;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
