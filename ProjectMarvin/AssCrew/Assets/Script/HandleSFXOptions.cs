using UnityEngine;
using System.Collections;

public class HandleSFXOptions : MonoBehaviour {
	
	private OptionsBehaviour optionsScript;
	
	public ChangeSFXVolume Add;
	public ChangeSFXVolume Remove;
	
	public float volume;
	
	// Use this for initialization
	void Start () {
		optionsScript = GameObject.Find("OptionsHandler").GetComponent<OptionsBehaviour>();
		volume = optionsScript.getSFXVolume();
	}
	
	public void DoStuff(float x){
		volume = optionsScript.getSFXVolume();
		if(x>0){
			volume = AddSomething(volume);
			optionsScript.setSFXVolume(volume);
		}
		else if(x<0){
			volume = RemoveSomething(volume);
			optionsScript.setSFXVolume(volume);
		}
	}
	
	
	public float AddSomething(float volume){
		return Add.Chose(volume);
	}
	
	public float RemoveSomething(float volume){
		return Remove.Chose(volume);
	}
	
	
}
