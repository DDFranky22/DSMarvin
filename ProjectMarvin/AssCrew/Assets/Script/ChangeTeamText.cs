using UnityEngine;
using System.Collections;

public class ChangeTeamText : MonoBehaviour {

	public GUIText scriptText;
	public LMGameSettings settings;

	public ChangeTeamSettings Add;
	public ChangeTeamSettings Remove;

	// Use this for initialization
	void Start () {
		scriptText = GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (settings.GetTeam ()) {
			scriptText.text = "Team    : Yes";	
		}
		else {
			scriptText.text = "Team    : No";	
		}
	}

	public void DoStuff(float x){
		if(x>0){
			AddSomething();
		}
		else if(x<0){
			RemoveSomething();
		}
	}


	public void AddSomething(){
		Remove.Deselected();
		Add.Selected();
		Add.Chose();
	}

	public void RemoveSomething(){
		Add.Deselected();
		Remove.Selected();
		Remove.Chose();
	}
}
