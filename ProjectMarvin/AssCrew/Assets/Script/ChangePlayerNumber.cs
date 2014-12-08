using UnityEngine;
using System.Collections;

public class ChangePlayerNumber : MonoBehaviour {

	public LMGameSettings settings;
	public GUIText scriptText;
	public ClickOnButton option;
	private int MaxPlayers;
	public bool add;

	// Use this for initialization
	void Start () {
		scriptText = GetComponent<GUIText> ();
		if(Input.GetJoystickNames().Length>=2){
			MaxPlayers = Input.GetJoystickNames().Length;
		}
		else{
			MaxPlayers = 2;
		}
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
		int p = settings.GetPlayers ();
		if (add) {
			if (p < MaxPlayers) {
				settings.SetPlayers (p + 1);
			}
		} 
		else {
			if(p>2){
				settings.SetPlayers (p -1);
			}
		}
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
