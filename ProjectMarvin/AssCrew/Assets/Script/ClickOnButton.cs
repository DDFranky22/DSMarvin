using UnityEngine;
using System.Collections;

public class ClickOnButton : MonoBehaviour {

	public string Scene;
	public GUIText scriptText;
	public bool Quit;

	// Use this for initialization
	void Start () {
		scriptText = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Selected(){
		scriptText.color = Color.grey;
		scriptText.fontStyle = FontStyle.Italic;
	}

	public void Deselect(){
		scriptText.color = Color.black;
		scriptText.fontStyle = FontStyle.Normal;
	}

	public void Chose(){
		if(Scene!="")
			Application.LoadLevel(Scene);
	}

	public void DoStuff(float x){
		if(this.gameObject.name=="Team Mode"){
			ChangeTeamText script = gameObject.GetComponent<ChangeTeamText>();
			script.DoStuff(x);
			return;
		}
		else if(this.gameObject.name=="Players"){
			ChangePlayerNumberText script = gameObject.GetComponent<ChangePlayerNumberText>();
			script.DoStuff(x);
			return;
		}
		else if(this.gameObject.name=="Round"){
			ChangeRoundNumberText script = gameObject.GetComponent<ChangeRoundNumberText>();
			script.DoStuff(x);
			return;
		}
		else if(this.gameObject.name=="People"){
			RefreshNumberOfNPC script = gameObject.GetComponent<RefreshNumberOfNPC>();
			script.DoStuff(x);
			return;
		}
		else if(this.gameObject.name=="Music"){
			HandleMusicOptions script = gameObject.GetComponent<HandleMusicOptions>();
			script.DoStuff(x);
			return;
		}
		else if(this.gameObject.name=="SFX"){
			HandleSFXOptions script = gameObject.GetComponent<HandleSFXOptions>();
			script.DoStuff(x);
			return;
		}
	}

	void OnMouseOver(){
		Selected();
	}

	void OnMouseExit(){
		Deselect();
	}

	void OnMouseDown(){
		if(!Quit)
			Chose();
		else
			Application.Quit();
	}
}
