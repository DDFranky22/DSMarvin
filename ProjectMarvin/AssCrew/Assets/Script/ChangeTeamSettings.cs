using UnityEngine;
using System.Collections;

public class ChangeTeamSettings : MonoBehaviour {

	public LMGameSettings settings;
	public bool value;
	public GUIText scriptText;

	void Start(){
		scriptText = GetComponent<GUIText> ();
	}

	public void Selected(){
		scriptText.color = Color.grey;
		scriptText.fontStyle = FontStyle.Italic;
	}

	public void Deselected(){
		scriptText.color = Color.black;
		scriptText.fontStyle = FontStyle.Normal;
	}

	public void Chose(){
		settings.SetTeam (value);
	}

	void OnMouseOver(){
		Selected();
	}
	
	void OnMouseExit(){
		Deselected();
	}
	
	void OnMouseDown(){
		Chose();
	}
}
