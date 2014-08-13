using UnityEngine;
using System.Collections;

public class ClicktoRemoveNPC : MonoBehaviour {


	public HandleNPCSettings script;
	private GUIText text;
	// Use this for initialization
	void Start () {
		text = GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		script.RemoveNPC ();
	}

	void OnMouseOver(){
		text.fontStyle = FontStyle.Italic;
		text.color = Color.grey;
	}

	void OnMouseExit(){
		text.color = Color.black;
		text.fontStyle = FontStyle.Normal;
	}
}
