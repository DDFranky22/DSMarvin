using UnityEngine;
using System.Collections;

public class RefreshServerListGUI : MonoBehaviour {
	public NetworkManager NetworkObject;
	public bool refresh;

	public GUIText scriptText;
	// Use this for initialization
	void Start () {
		NetworkObject = GameObject.Find("NetworkManager").GetComponent<NetworkManager>()as NetworkManager;
		StartCoroutine(CheckEveryXSeconds());
		scriptText = GetComponent<GUIText>();
	}

	IEnumerator CheckEveryXSeconds(){
		while(refresh){
			NetworkObject.RefreshHostList();
			yield return new WaitForSeconds(1.0f);
		}
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
		NetworkObject.AmIServer = false;
		Application.LoadLevel("Intermezzo");
		//NetworkObject.RefreshHostList();
		print ("Hai premuto il pulsante di refresh");
	}
}
