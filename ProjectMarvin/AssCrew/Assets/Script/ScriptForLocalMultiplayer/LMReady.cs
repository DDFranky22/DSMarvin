using UnityEngine;
using System.Collections;

public class LMReady : MonoBehaviour {

	public bool Ready;
	public KeyCode button;
	public float windowWidth;
	public float windowHeight;
	public float offsetX;
	public float offsetY;
	public LMPlayerMovementLobby scriptMov;
	public int N;
	public LMLobbyManager LM;

	public GameObject ReadyWord;
	public MeshRenderer render;

	public int PlayerNumber;
	private bool PressedReady;

	// Use this for initialization
	void Start () {
		windowWidth = 100.0f;
		windowHeight = 100.0f;
		offsetX = 31.0f;
		offsetY = -117.0f;
		scriptMov = GetComponent<LMPlayerMovementLobby>();
		N = scriptMov.Number;
		LM = GameObject.Find("LMLobbyManager").GetComponent<LMLobbyManager>();
		render = ReadyWord.GetComponent<MeshRenderer>();
		render.enabled = false;
		PressedReady = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKeyDown(button)){
		if(Input.GetAxis("X_"+(PlayerNumber+1))>0&&!PressedReady){
			PressedReady = true;
			Ready = !Ready;
			if(Ready){
				render.enabled = true;
			}
			else{
				render.enabled = false;
			}
			LM.RegistPlayer(N,Ready);
		}
		if(Input.GetAxis("X_"+(PlayerNumber+1))<=0){
			PressedReady = false;
		}
	}

}
