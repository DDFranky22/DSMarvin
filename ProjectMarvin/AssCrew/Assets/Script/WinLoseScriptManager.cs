using UnityEngine;
using System.Collections;

public class WinLoseScriptManager : MonoBehaviour {

	public string Text;

	private GUIText textmesh;
	// Use this for initialization
	void Start () {
		textmesh = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		textmesh.text = Text;
	}

	[RPC]
	void ChangeOtherText(string v){
		Text = v;
	}

	public void ChangeText(string t, string v){
		Text = t;
		networkView.RPC("ChangeOtherText",RPCMode.Others,v);
	}

}
