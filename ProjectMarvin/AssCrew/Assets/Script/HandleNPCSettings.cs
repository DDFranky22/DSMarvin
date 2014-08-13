using UnityEngine;
using System.Collections;

public class HandleNPCSettings : MonoBehaviour {

	public LMGameSettings settings;

	public int Players;
	public int Set;
	// Use this for initialization
	void Start () {
		Set = 10;
		Players = settings.GetPlayers ();
		int temp = Players * Set;
		settings.SetNPC(temp);
	}
	
	// Update is called once per frame
	void Update () {
		int tempPlayers = settings.GetPlayers ();
		if (tempPlayers != Players) {
			Players = tempPlayers;
			Calc(Set);
		}
	}

	public void AddNPC(){
		if (Set < 20) {
			Set+=5;
			Calc(Set);
		}
	}

	public void RemoveNPC(){
		if (Set > 10) {
			Set-=5;
			Calc(Set);
		}
	}

	private void Calc(int Set){
		int temp = Players * Set;
		settings.SetNPC(temp);
	}

}
