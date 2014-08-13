using UnityEngine;
using System.Collections;

public class LMGameSettings : MonoBehaviour {

	public int Players;
	public int Round;
	public int NPC;
	public int RoundToEnd;
	public int CurrentRound;
	public int[] RoundWinner;
	public bool Team;


	void Update(){
		DontDestroyOnLoad(this.gameObject);
	}


	public void SetPlayers(int x){
		Players = x;
	}

	public int GetPlayers(){
		return Players;
	}

	public void SetRound(int x){
		Round = x;
		RoundToEnd = Round+1;
		RoundWinner = new int[Round];
	}
	
	public int GetRound(){
		return RoundToEnd;
	}

	public int GetRealRound(){
		return Round;
	}

	public void RoundOver(){
		RoundToEnd--;
	}

	public void SetNPC(int x){
		NPC = x;
	}
	
	public int GetNPC(){
		return NPC;
	}

	public void SetRoundWinner(int round, int winner){
		RoundWinner[round] = winner;
	}

	public int GetRoundWinner(int i){
		return RoundWinner[i];
	}

	public void SetCurrentRound(int x){
		CurrentRound = x;
	}

	public int GetCurrentRound(){
		return CurrentRound;
	}

	public void SetTeam(bool v){
		Team = v;
	}

	public bool GetTeam(){
		return Team;
	}

	public int GivePlayerWin(int x){
		int round = 0;
		for(int i = 0;i<RoundWinner.Length;i++){
			if(RoundWinner[i]==x){
				round++;
			}
		}
		return round;
	}

}
