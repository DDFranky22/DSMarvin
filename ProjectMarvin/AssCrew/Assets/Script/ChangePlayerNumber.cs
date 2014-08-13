using UnityEngine;
using System.Collections;

public class ChangePlayerNumber : MonoBehaviour {

	public LMGameSettings settings;
	public GUIText scriptText;

	public bool add;

	// Use this for initialization
	void Start () {
		scriptText = GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
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
		int p = settings.GetPlayers ();
		if (add) {
			if (p < 4) {
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
	}
	
	void OnMouseExit(){
		Deselected();
	}
	
	void OnMouseDown(){
		Chose();
	}
}
