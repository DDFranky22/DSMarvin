using UnityEngine;
using System.Collections;

public class AnimationManagerNPC3D : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void Walk(bool value){
		anim.SetBool("Walk",value);
	}

	public bool GetWalkValue(){
		return anim.GetBool("Walk");
	}
	
	public void Run(bool value){
		anim.SetBool("Run",value);
	}

	public bool GetRunValue(){
		return anim.GetBool("Run");
	}

	public void Idle(bool value){
		anim.SetBool("Idle",value);
	}

	public bool GetIdleValue(){
		return anim.GetBool("Idle");
	}

	public void Salute(bool value){
		anim.SetBool("Hi",value);
	}

	void OnPlayerDisconnected(NetworkPlayer player){
		Debug.Log("Giocatore disconnesso");
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
}
