using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckingVictory : MonoBehaviour {

	public bool [] Players;
	public int index;
	public int Controllo;
	public WinLoseScriptManager win;
	public int NumberOfPlayers;
	// Use this for initialization
	void Start () {
		NumberOfPlayers = GameObject.Find("NetworkManager").GetComponent<NetworkManager>().getPlayersNumber();
		Players = new bool[NumberOfPlayers];
		win = GameObject.Find("Win/Lose").GetComponent<WinLoseScriptManager>();
	}

	// Update is called once per frame
	void Update () {
	}

	public int RegisterPlayer(){
		Players[index] = true;
		index++;
		return index;
	}

	public void RemovePlayer(int i){
		Players[i-1] = false;
		CheckIfOver();
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info){
		bool[] sup = new bool[NumberOfPlayers];
		for(int i = 0;i<sup.Length;i++){
			if (stream.isWriting) {
				sup[i] = Players[i];
				stream.Serialize(ref sup[i]);
			} else {
				stream.Serialize(ref sup[i]);
				Players[i] = sup[i];
			}
		}
	}

	void CheckIfOver(){
		int count = 0;
		for(int i = 0;i<Players.Length;i++){
			if(Players[i]==true)
				count++;
		}
		if(count==1){
			win.ChangeText("You Win","You Lose");
		}
	}
}
