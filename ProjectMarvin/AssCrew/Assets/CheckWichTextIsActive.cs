using UnityEngine;
using System.Collections;

public class CheckWichTextIsActive : MonoBehaviour {

	public ClickOnButton[] option;
	public GameObject[] helpText;
	public bool On;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1)||Input.GetKeyDown (KeyCode.Joystick1Button3)){
			On = !On;
		}
		if(On){
			for(int i = 0;i<option.Length;i++){
				ClickOnButton o = option[i];
				if(o.sel){
					helpText[i].SetActive(true);
				}
				else{
					helpText[i].SetActive(false);
				}
			}
		}
		else{
			for(int i = 0;i<option.Length;i++){
				helpText[i].SetActive(false);
			}
		}
	}
}
