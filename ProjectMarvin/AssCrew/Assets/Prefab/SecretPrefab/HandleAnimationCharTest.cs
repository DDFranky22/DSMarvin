using UnityEngine;
using System.Collections;

public class HandleAnimationCharTest : MonoBehaviour {

	public Animator anim;
	public float IdleSX;
	public float IdleSY;
	public float WalkSX;
	public float WalkSY;
	public float RunSX;
	public float RunSY;


	public float DimensionX;
	public float DimensionY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width/IdleSX,Screen.height/IdleSY,Screen.width/DimensionX,Screen.height/DimensionY),"Idle")){
			anim.SetBool("Idle",true);
			anim.SetBool("Walk",false);
			anim.SetBool("Run",false);
		}
		if(GUI.Button(new Rect(Screen.width/WalkSX,Screen.height/WalkSY,Screen.width/DimensionX,Screen.height/DimensionY),"Walk")){
			anim.SetBool("Idle",false);
			anim.SetBool("Walk",true);
			anim.SetBool("Run",false);
		}
		if(GUI.Button(new Rect(Screen.width/RunSX,Screen.height/RunSY,Screen.width/DimensionX,Screen.height/DimensionY),"Run")){
			anim.SetBool("Idle",false);
			anim.SetBool("Walk",false);
			anim.SetBool("Run",true);
		}
	}
}
