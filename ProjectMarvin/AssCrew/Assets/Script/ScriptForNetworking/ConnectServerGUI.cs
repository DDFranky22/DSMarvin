using UnityEngine;
using System.Collections;

public class ConnectServerGUI : MonoBehaviour {

	public NetworkManager NetworkObject;

	public GUIText scriptText;

	// Use this for initialization
	void Start () {
		NetworkObject = GameObject.Find("NetworkManager").GetComponent<NetworkManager>()as NetworkManager;
		scriptText = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Network.isClient || Network.isServer)
			this.gameObject.renderer.enabled = false;
	
	}


	void OnMouseOver(){
		scriptText.color = Color.grey;
		scriptText.fontStyle = FontStyle.Italic;
	}
	
	void OnMouseExit(){
		scriptText.color = Color.black;
		scriptText.fontStyle = FontStyle.Normal;
	}

	void OnMouseDown(){
		NetworkObject.AmIServer = true;
		Application.LoadLevel("Intermezzo");
	}
}
