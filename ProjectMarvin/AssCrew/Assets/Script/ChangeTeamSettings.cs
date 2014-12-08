using UnityEngine;
using System.Collections;

public class ChangeTeamSettings : MonoBehaviour {

	public LMGameSettings settings;
	public bool value;
	public GUIText scriptText;
	public ClickOnButton option;

	void Start(){
		scriptText = GetComponent<GUIText> ();
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
		settings.SetTeam (value);
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
