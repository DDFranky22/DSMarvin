
using UnityEngine;
using System.Collections;

public class OptionsBehaviour : MonoBehaviour {

	public float VolumeMusic;
	private	float VolumeSFX;
	private Resolution screenResolution;

	// Use this for initialization
	void Start () {
		GameObject clone = GameObject.Find("OptionsHandler") as GameObject;
		if(clone!=null&&clone!=this.gameObject){
			Destroy(clone);
		}
		if(PlayerPrefs.GetFloat("VolumeMusic")!=null){
			VolumeMusic = PlayerPrefs.GetFloat("VolumeMusic");
			VolumeSFX = PlayerPrefs.GetFloat("VolumeSFX");
		}
		else{
			VolumeMusic = 0.0f;
			VolumeSFX = 0.0f;
		}
		screenResolution = Screen.currentResolution;
	}

	public void setMusicVolume(float x){
		VolumeMusic = x;
		PlayerPrefs.SetFloat("VolumeMusic",VolumeMusic);
	}

	public float getMusicVolume(){
		return VolumeMusic;
	}

	public void setSFXVolume(float x){
		VolumeSFX = x;
		PlayerPrefs.SetFloat("VolumeSFX",VolumeSFX);
	}

	public float getSFXVolume(){
		return VolumeSFX;
	}


	public void setCurrentResolution(Resolution r){
		screenResolution = r;
	}

	public Resolution getCurrentResolution(){
		return screenResolution;
	}

	public Resolution[] getAllResolutions(){
		return Screen.resolutions;
	}

	void Update(){
		DontDestroyOnLoad(this.gameObject);
	}

}
