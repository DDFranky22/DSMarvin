using UnityEngine;
using System.Collections;

public class ControllerMenuManager : MonoBehaviour {

	public GameObject[] Scritte;
	public ClickOnButton[] scriptScritte;
	public ClickOnButton Quit;

	public int i;

	private bool Down;
	private bool Up;

	private bool horizontalMove;

	public string[] Joysticks;
	// Use this for initialization
	void Start () {
		i =0;
		int j = 0;
		scriptScritte = new ClickOnButton[Scritte.Length];
		foreach (GameObject g in Scritte){
			scriptScritte[j] = g.GetComponent<ClickOnButton>();
			j++;
		}
		Joysticks = Input.GetJoystickNames();
	}

	// Update is called once per frame
	void Update () {
		if(Joysticks.Length>0){
			if(Input.GetAxis("Vertical")>0.5f&&!Down){
				i--;
				Down = true;
				Up = false;
			}
			if(Input.GetAxis("Vertical")<-0.5f&&!Up){
				i++;
				Down = false;
				Up = true;
			}
			if(Input.GetAxis("Vertical")==0){
				Down = false;
				Up = false;
			}
			if(i<0){
				i = 0;
			}
			if(i>Scritte.Length-1){
				i = Scritte.Length-1;
			}
			if(Input.GetKeyDown(KeyCode.Joystick1Button0)){
				ChoseButton(i);
			}
			if(Input.GetKeyDown(KeyCode.Joystick1Button1)){
				Back();
			}
			if(scriptScritte.Length>0){
				SelectedButton(i);
				DeselectOther(i);
			}
			if((Input.GetAxis("Horizontal")<-0.5f || Input.GetAxis("Horizontal")>0.5f)&&!horizontalMove){
				DoStuff(Input.GetAxis("Horizontal"));
				horizontalMove=true;
			}
			if(Input.GetAxis("Horizontal")==0){
				horizontalMove = false;
			}
		}
	}

	private void SelectedButton(int i){
		ClickOnButton button = scriptScritte[i];
		button.Selected();
	}

	private void DeselectOther(int i){
		for(int j=0;j<scriptScritte.Length;j++){
			if(j!=i){
				ClickOnButton button = scriptScritte[j];
				button.Deselect();
			}
		}
	}

	private void ChoseButton(int i){
		ClickOnButton button = scriptScritte[i];
		button.Chose();
	}

	private void Back(){
		if(Quit!=null)
			Quit.Chose();
	}

	private void DoStuff(float x){
		ClickOnButton button = scriptScritte[i];
		button.DoStuff(x);
	}
}	
