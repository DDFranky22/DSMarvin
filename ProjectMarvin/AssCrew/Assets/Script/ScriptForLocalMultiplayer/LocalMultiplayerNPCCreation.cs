using UnityEngine;
using System.Collections;

public class LocalMultiplayerNPCCreation : MonoBehaviour {
	
	public float NumberOfNPC;
	public float MaxX;
	public float MaxY;
	public float MinX;
	public float MinY;
	
	public GameObject NPCPrefab;

	public LMGameSettings gameSettings;

	public Material[] materiali;
	// Use this for initialization
	void Start () {
		gameSettings = GameObject.Find("GameSettingsManager").GetComponent<LMGameSettings>();
		NumberOfNPC = gameSettings.GetNPC();
		int Players = gameSettings.GetPlayers ();
		int Division = (int) NumberOfNPC / Players;
		int j = 0;
		if (!gameSettings.GetTeam ()) {
			Material black = materiali[3];
			for(int i = 0;i<materiali.Length;i++){
				materiali[i] = black;
			}
		}

		for(int i=1;i<=NumberOfNPC;i++){
			GameObject temp = Instantiate(NPCPrefab,new Vector3(Random.Range(MinX,MaxX),0.0f,Random.Range(MinY,MaxY)),Quaternion.identity) as GameObject;
			GameObject Test = temp.transform.FindChild("Test02").gameObject;
			GameObject Omino = Test.transform.FindChild("omino3").gameObject;
				if((Division*(j+1)) - i < 0)
					j++;
			Omino.renderer.material = materiali[j];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
