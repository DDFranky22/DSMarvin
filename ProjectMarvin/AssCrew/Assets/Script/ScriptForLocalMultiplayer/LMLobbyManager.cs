using UnityEngine;
using System.Collections;

public class LMLobbyManager : MonoBehaviour {

	public bool[] Ready;
	public int NPlayers;
	public bool Begin;
	public int Seconds;
	public float startx;
	public float starty;

	public LMGameSettings settings;
	// Use this for initialization
	void Start () {
		settings = GameObject.Find ("GameSettingsManager").GetComponent<LMGameSettings> ();
		NPlayers = settings.GetPlayers ();
		Ready = new bool[NPlayers];
		StartCoroutine(BeginGame());
		Seconds = 4;
		startx = 1.2f;
		starty = 50.0f;
	}

	public void RegistPlayer(int x, bool v){
		Ready[x] = v;
	}


	IEnumerator BeginGame(){
		while(!Begin){
			Begin = CheckIfBegin();
			yield return new WaitForSeconds(0.1f);
		}
		for(int i = 0;i<4;i++){
			Seconds -= 1;
			Begin = CheckIfBegin();
			if(!Begin){
				Seconds = 4;
				StartCoroutine(BeginGame());
				return false;
			}
			yield return new WaitForSeconds(1.0f);
		}
		Application.LoadLevel("LocalMultiplayerTest");
	}


	private bool CheckIfBegin(){
		int x = 0;
		for(int i = 0;i<Ready.Length;i++){
			if(Ready[i])
				x++;
		}
		if(x.Equals(Ready.Length))
			return true;
		return false;
	}

	void OnGUI(){
		if(Begin){
			GUI.skin.label.normal.textColor = Color.black;
			GUI.Label(new Rect(Screen.width/startx,Screen.height/starty,Screen.width,Screen.height),"Game start in: "+Seconds);
		}
	}
}
