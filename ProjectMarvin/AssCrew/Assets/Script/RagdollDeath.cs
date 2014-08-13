using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RagdollDeath : MonoBehaviour {

	public List<Collider> col;
	public List<Rigidbody> rigB;

	// Use this for initialization
	void Start () {
		col = new List<Collider>();
		col.AddRange(gameObject.GetComponentsInChildren<Collider>());
		foreach (Collider c in col){
			c.isTrigger = true;
		}
		rigB = new List<Rigidbody>();
		rigB.AddRange(gameObject.GetComponentsInChildren<Rigidbody>());
		foreach (Rigidbody r in rigB){
			r.isKinematic = true;
		}
	}


	public void DieAnimations(){
		foreach (Collider c in col){
			c.isTrigger = false;
		}
		foreach (Rigidbody r in rigB){
			r.isKinematic = false;
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
