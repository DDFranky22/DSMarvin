using UnityEngine;
using System.Collections;

public class OCheckModePlayer : MonoBehaviour {

	private NetworkManager nm;
	private GUIText text;
	// Use this for initialization
	void Start () {
		nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		text = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		if(nm.getPlayerSpectator()){
			text.text = "Mode    : Player";
		}
		else{
			text.text = "Mode    : Spectator";
		}
	
	}
}
