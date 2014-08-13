using UnityEngine;
using System.Collections;

public class LMCheckingVictory : MonoBehaviour {

	public bool[] Dead;
	public LMGUIVictory text;
	public LMGameSettings gameSettings;
	public bool first;

	// Use this for initialization
	void Start () {
		gameSettings = GameObject.Find("GameSettingsManager").GetComponent<LMGameSettings>();
		Dead = new bool[gameSettings.GetPlayers()];
		text = GameObject.Find("VictoryGUI").GetComponent<LMGUIVictory>();
		gameSettings.RoundOver();
		first = true;
	}

	IEnumerator LoadLobbyAgain(){
		if(first){
			first = false;
			yield return new WaitForSeconds(5.0f);
			Application.LoadLevel("LMLobby");
		}
	}

	IEnumerator LoadMenuAgain(){
		if(first){
			first = false;
			yield return new WaitForSeconds(5.0f);
			Destroy (gameSettings.gameObject);
			Application.LoadLevel("LMGameCreation");
		}
	}

	// Update is called once per frame
	void Update () {
	}

	public void KillMe(int i){
		Dead[i] = true;
		text.KilledPlayer(i);
		CheckVictoryCondition();
	}

	public int WinnerIs(){
		int one, two, three, four;
		one = two = three = four = 0;
		for(int i = 0 ; i<gameSettings.RoundWinner.Length;i++){
			int temp = gameSettings.GetRoundWinner(i);
			switch(temp){
			case 1: one++; break;
			case 2: two++; break;
			case 3: three++; break;
			case 4: four++; break;
			default: break;
			}
		}
		int Most =Mathf.Max(Mathf.Max(Mathf.Max(one, two), three),four);
		if(Most==one){
			return 1;
		}
		else if(Most==two){
			return 2;
		}
		else if(Most==three){
			return 3;
		}
		else if(Most==four){
			return 4;
		}
		else
			return -1;
	}


	public void CheckVictoryCondition(){
		int Alive = 0;
		for(int i = 0;i<Dead.Length;i++)
			if(!Dead[i])
				Alive++;
		if(Alive==1){
			for(int i = 0;i<Dead.Length;i++){
				if(!Dead[i]){
					if(gameSettings.RoundToEnd>1){
						text.ShowText(i+1);
						gameSettings.SetRoundWinner(gameSettings.Round-gameSettings.RoundToEnd,i+1);
						//print ("Inserito in: "+(gameSettings.Round-gameSettings.RoundToEnd)+" Il valore: "+(i+1));
						StartCoroutine(LoadLobbyAgain());
						return;
					}
					else{
						text.ShowTextRound(WinnerIs());
						gameSettings.SetRoundWinner(gameSettings.Round-gameSettings.RoundToEnd,i+1);
						//print ("Inserito in: "+(gameSettings.Round-gameSettings.RoundToEnd)+" Il valore: "+(i+1));
						StartCoroutine(LoadMenuAgain());
						return;
					}
				}
			}
		}
	}

}
