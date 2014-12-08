using UnityEngine;
using System.Collections;

public class ChangeRoundNumberText : MonoBehaviour {
	public LMGameSettings settings;
	private GUIText scriptText;

	public ChangeRoundNumber Add;
	public ChangeRoundNumber Remove;
	
	// Use this for initialization
	void Start () {
		scriptText = GetComponent<GUIText> ();
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
	
	// Update is called once per frame
	void Update () {
		scriptText.text = "First to : " + settings.GetRealRound ();
	}
}
