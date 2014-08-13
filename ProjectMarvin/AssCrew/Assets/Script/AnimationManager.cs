using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void WalkDown(bool value){
			anim.SetBool("WalkDown",value);
			networkView.RPC("SetWalkDown",RPCMode.Others,value);
	}

	public void WalkLeft(bool value){
			anim.SetBool("WalkLeft",value);
			networkView.RPC("SetWalkLeft",RPCMode.Others,value);
	}

	public void WalkRight(bool value){
			anim.SetBool("WalkRight",value);
			networkView.RPC("SetWalkRight",RPCMode.Others,value);
	}

	public void WalkUp(bool value){
			anim.SetBool("WalkUp",value);
			networkView.RPC("SetWalkUp",RPCMode.Others,value);
	}

	public void Idle(bool value){
			anim.SetBool("Idle",value);
			networkView.RPC("SetIdle",RPCMode.Others,value);
	}

	[RPC]
	void SetWalkDown(bool value){
		anim.SetBool("WalkDown",value);
	}
	[RPC]
	void SetWalkLeft(bool value){
		anim.SetBool("WalkLeft",value);
	}

	[RPC]
	void SetWalkRight(bool value){
		anim.SetBool("WalkRight",value);
	}

	[RPC]
	void SetWalkUp(bool value){
		anim.SetBool("WalkUp",value);
	}
	[RPC]
	void SetIdle(bool value){
		anim.SetBool("Idle",value);
	}

	void OnPlayerDisconnected(NetworkPlayer player){
		Debug.Log("Giocatore disconnesso");
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
}
