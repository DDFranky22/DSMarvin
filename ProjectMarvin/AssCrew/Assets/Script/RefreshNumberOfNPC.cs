using UnityEngine;
using System.Collections;

public class RefreshNumberOfNPC : MonoBehaviour {

	public LMGameSettings gameSettings;
	public GUIText scriptText;

	public ChangeNumberNPC Add;
	public ChangeNumberNPC Remove;

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
		scriptText.text = "People  : "+gameSettings.GetNPC ();
	}
}
