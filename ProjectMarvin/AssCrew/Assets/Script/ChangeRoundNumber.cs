using UnityEngine;
using System.Collections;

public class ChangeRoundNumber : MonoBehaviour {

	public LMGameSettings settings;

	public GUIText scriptText;
	
	public bool add;

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
		int r = settings.GetRealRound ();
		if (add) {
			if (r < 7) {
				settings.SetRound (r+2);
			}
		} 
		else {
			if(r>1){
				settings.SetRound (r -2);
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
