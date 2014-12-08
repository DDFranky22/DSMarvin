using UnityEngine;
using System.Collections;

public class ChangeRoundNumber : MonoBehaviour {

	public LMGameSettings settings;

	public GUIText scriptText;
	public ClickOnButton option;
	
	public bool add;

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
		int r = settings.GetRealRound ();
		if (add) {
			if (r < 4) {
				settings.SetRound (r+1);
			}
		} 
		else {
			if(r>1){
				settings.SetRound (r-1);
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
