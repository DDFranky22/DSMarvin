using UnityEngine;
using System.Collections;

public class HandleMusicOptions : MonoBehaviour {

	private OptionsBehaviour optionsScript;

	public ChangeMusicVolume Add;
	public ChangeMusicVolume Remove;

	public float volume;

	// Use this for initialization
	void Start () {
		optionsScript = GameObject.Find("OptionsHandler").GetComponent<OptionsBehaviour>();
		volume = optionsScript.getMusicVolume();
	}

	public void DoStuff(float x){
		volume = optionsScript.getMusicVolume();
		if(x>0){
			volume = AddSomething(volume);
			optionsScript.setMusicVolume(volume);
		}
		else if(x<0){
			volume = RemoveSomething(volume);
			optionsScript.setMusicVolume(volume);
		}
	}
	
	
	public float AddSomething(float volume){
		return Add.Chose(volume);
	}
	
	public float RemoveSomething(float volume){
		return Remove.Chose(volume);
	}


}
