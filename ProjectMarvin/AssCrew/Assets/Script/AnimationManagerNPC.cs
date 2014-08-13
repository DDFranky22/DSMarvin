using UnityEngine;
using System.Collections;

public class AnimationManagerNPC : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void WalkDown(bool value){
		anim.SetBool("WalkDown",value);
	}
	
	public void WalkLeft(bool value){
		anim.SetBool("WalkLeft",value);
	}
	
	public void WalkRight(bool value){
		anim.SetBool("WalkRight",value);
	}
	
	public void WalkUp(bool value){
		anim.SetBool("WalkUp",value);
	}
	
	public void Idle(bool value){
		anim.SetBool("Idle",value);
	}

	void OnPlayerDisconnected(NetworkPlayer player){
		Debug.Log("Giocatore disconnesso");
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}

}
