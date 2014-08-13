using UnityEngine;
using System.Collections;

public class LMCreatePlayers : MonoBehaviour {
	
	public float NumberOfPlayers;
	public float MaxX;
	public float MaxY;
	public float MinX;
	public float MinY;
	
	public GameObject PlayerPrefab;

	public LMGameSettings gameSettings;

	public Material[] materiali;

	// Use this for initialization
	void Start () {
		gameSettings = GameObject.Find("GameSettingsManager").GetComponent<LMGameSettings>();
		NumberOfPlayers = gameSettings.GetPlayers();
		if (!gameSettings.GetTeam ()) {
			Material black = materiali[3];
			for(int i = 0;i<materiali.Length;i++){
				materiali[i] = black;
			}
		}
		for(int i = 0; i<NumberOfPlayers;i++){
		GameObject _one =  Instantiate(PlayerPrefab,new Vector3(Random.Range(MinX,MaxX),0.0f,Random.Range(MinY,MaxY)),Quaternion.identity) as GameObject;
		LMPlayerMovement scriptMov = _one.GetComponent<LMPlayerMovement>();
		GameObject Test = _one.transform.FindChild("Test02").gameObject;
		GameObject Omino = Test.transform.FindChild("omino3").gameObject;
		Omino.renderer.material = materiali[i];
		scriptMov.Number = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
