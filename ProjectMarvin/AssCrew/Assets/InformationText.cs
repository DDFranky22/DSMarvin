using UnityEngine;
using System.Collections;

public class InformationText : MonoBehaviour {

	public string[] testo;
	public GUISkin skin;
	private string text;
	public float XStart;
	public float YStart;
	public float XDim;
	public float YDim;
	public int fontsize;
	// Use this for initialization
	void Start () {
		foreach(string s in testo){
			text += s+"\n\r";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		float width = Screen.width;
		float height = Screen.height;
		GUI.skin = skin;
		skin.label.fontSize = (int) (width/fontsize);
		GUI.Label(new Rect(width/XStart,height/YStart,width/XDim,height/YDim),text);
	}
}
