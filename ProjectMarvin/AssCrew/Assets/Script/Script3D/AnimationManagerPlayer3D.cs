using UnityEngine;
using System.Collections;

public class AnimationManagerPlayer3D : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void Walk(bool value){
		anim.SetBool("Walk",value);
	}
	
	public void Run(bool value){
		anim.SetBool("Run",value);
	}
	public void Idle(bool value){
		anim.SetBool("Idle",value);
	}

	public bool IsWalking(){
		return anim.GetBool("Walk");
	}

	public void Salute(bool v){
		anim.SetBool ("Hi", v);
	}

	public bool SaluteYou(){
		return anim.GetBool ("Hi");
	}

	void OnPlayerDisconnected(NetworkPlayer player){
		Debug.Log("Giocatore disconnesso");
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
}
