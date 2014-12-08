using UnityEngine;
using System.Collections;

public class ChangeNumberNPC : MonoBehaviour {

	public HandleNPCSettings script;
	public ClickOnButton option;
	private GUIText	scriptText;

	public bool remove;

	// Use this for initialization
	void Start () {
		scriptText = GetComponent<GUIText> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Selected(){
		scriptText.color = Color.black;
		scriptText.fontStyle = FontStyle.Normal;
	}
	
	public void Deselected(){
		scriptText.color = Color.grey;
		scriptText.fontStyle = FontStyle.Italic;
	}
	
	public void Chose(){
		if(!remove)
			script.AddNPC ();
		else
			script.RemoveNPC();
	}
	
	
	void OnMouseOver(){
		Selected();
		option.Selected();
	}
	
	void OnMouseExit(){
		Deselected();
		option.Deselect();
	}
	
	void OnMouseDown(){
		Chose();
	}
}
