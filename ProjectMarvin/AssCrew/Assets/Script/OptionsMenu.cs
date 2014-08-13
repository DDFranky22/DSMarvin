using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

	public GUISkin customSkin;
	private OptionsBehaviour optionsSettings;

	private float MusicValue;
	private float SFXValue;
	public bool Fullscreen;

	private Resolution resolution;

	//valori per la GUI

	public float XStart;

	public float YStartMusic;
	public float XDimMusic;
	public float YDimMusic;

	public float YStartSFX;
	public float XDimSFX;
	public float YDimSFX;

	public float YStartFullscreen;
	public float XDimFullscreen;
	public float YDimFullscreen;

	//valori per la GUI


	// Use this for initialization
	void Start () {
		optionsSettings = GameObject.Find("OptionsHandler").GetComponent<OptionsBehaviour>();
		MusicValue = optionsSettings.getMusicVolume();
		SFXValue = optionsSettings.getSFXVolume();
		Fullscreen = Screen.fullScreen;
		resolution = optionsSettings.getCurrentResolution();

		XStart = 62.0f;
		YStartMusic = 55.0f;
		XDimMusic = 100.0f;
		YDimMusic = 15;
		YStartSFX = 80.0f;
		XDimSFX = 100.0f;
		YDimSFX = 15.0f;
		YStartFullscreen = 120.0f;
		XDimFullscreen = 15.0f;
		YDimFullscreen = 15.0f;
	}

	void OnGUI(){
		GUI.skin = customSkin;
		MusicValue = GUI.HorizontalSlider(new Rect(XStart,YStartMusic,XDimMusic,YDimMusic),optionsSettings.getMusicVolume(),0.0f,1.0f);
		optionsSettings.setMusicVolume(MusicValue);
		SFXValue = GUI.HorizontalSlider(new Rect(XStart,YStartSFX,XDimSFX,YDimSFX),optionsSettings.getSFXVolume(),0.0f,1.0f);
		optionsSettings.setSFXVolume(SFXValue);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
