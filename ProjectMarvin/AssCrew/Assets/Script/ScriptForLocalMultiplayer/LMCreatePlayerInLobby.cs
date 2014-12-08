using UnityEngine;
using System.Collections;

public class LMCreatePlayerInLobby : MonoBehaviour {

	public GameObject PlayerPrefab;
	public int NumberOfPlayers;
	public LMGameSettings scriptSettings;
	public Material[] materiali;
	// Use this for initialization
	void Start () {
		scriptSettings = GameObject.Find("GameSettingsManager").GetComponent<LMGameSettings>();
		NumberOfPlayers = scriptSettings.GetPlayers();
		if (!scriptSettings.GetTeam ()) {
			Material black = materiali[3];
			for(int i = 0;i<materiali.Length;i++){
				materiali[i] = black;
			}
		}
		for(int i = 0;i<NumberOfPlayers;i++){
			GameObject temp = Instantiate(PlayerPrefab,new Vector3(Random.Range(-9,9),0,Random.Range(-8,8)),Quaternion.identity) as GameObject;
			LMPlayerMovementLobby script = temp.GetComponent<LMPlayerMovementLobby>();
			GameObject Test = temp.transform.FindChild("casamaryominodue").gameObject;
			GameObject Omino = Test.transform.FindChild("omino5").gameObject;
			Omino.renderer.material = materiali[i];
			script.Number = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
