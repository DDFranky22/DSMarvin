using UnityEngine;
using System.Collections;

public class LMNPCBehaviour : MonoBehaviour {
	
	public Vector3 Direction;
	NavMeshAgent scriptAgent;
	public AnimationManagerNPC3D anim;
	public float WalkSpeed;
	public float RunSpeed;
	public bool Move;
	public bool alive;
	public RagdollDeath scriptDeath;
	public float WalkMaxX;
	public float WalkMaxY;
	public float WalkMinX;
	public float WalkMinY;
	// Use this for initialization
	void Start () {
		alive = true;
		Move = true;
		scriptAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<AnimationManagerNPC3D>();
		scriptAgent.updateRotation= false;
		Direction = this.transform.position;
		scriptDeath = GetComponentInChildren<RagdollDeath>();
		StartCoroutine(CoroutineRoute());
	}

	
	IEnumerator CoroutineRoute(){
		for(int i = 0;i<3;i++){
			yield return new WaitForSeconds(1.0f);
		}
		Direction = this.transform.position;
		while(alive&&Move){
			Direction = new Vector3(Random.Range(WalkMinX,WalkMaxX),0.0f,Random.Range(WalkMinY,WalkMaxY));
			if(Random.Range(0.0f,1.0f)>0.9f){
				scriptAgent.speed = 0.0f;
				anim.Salute(true);
				yield return new WaitForSeconds(2.0f);
				anim.Salute(false);
			}
			if(Random.Range(0.0f,1.0f)>0.7f){
				scriptAgent.speed = RunSpeed;
			}
			else
				scriptAgent.speed = WalkSpeed;
			yield return new WaitForSeconds(Random.Range(3.0f,10.0f));
		}
	}
	
	void HandleAnimations(){
		if(this.transform.position.x!=Direction.x&&this.transform.position.z!= Direction.z){
			if(scriptAgent.speed == WalkSpeed){
				anim.Walk(true);
				anim.Run(false);
			}
			else{
				anim.Walk(true);
				anim.Run(false);
			}
			anim.Idle(false);
		}
		if(this.transform.position.x==Direction.x&&this.transform.position.z== Direction.z){
			anim.Idle(true);
			anim.Walk(false);
			anim.Run(false);
		}
	}



	public void Die(){
		alive = false;
		scriptAgent.enabled = false;
		anim.anim.enabled = false;
		scriptDeath.DieAnimations();
	}
	// Update is called once per frame
	void Update () {
		if(alive&&Move){
			scriptAgent.SetDestination(Direction);
			transform.LookAt(new Vector3(Direction.x,this.transform.position.y,Direction.z));
			HandleAnimations ();
		}
		else if(!Move){
			if(alive)
				Debug.Log("Non mi muovo");
			scriptAgent.SetDestination(new Vector3(this.transform.position.x,0.0f,this.transform.position.z));
			transform.LookAt(new Vector3(Direction.x,this.transform.position.y,Direction.z));
			HandleAnimations ();
		}
	}
}
