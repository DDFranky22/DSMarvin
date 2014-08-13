using UnityEngine;
using System.Collections;

public class NPCBehaviour : MonoBehaviour {
	
	public Vector3 Direction;
	NavMeshAgent scriptAgent;
	public GameObject ball;
	public static bool Murder;
	public static Vector3 PositionMurder;
	public AnimationManagerNPC3D anim;
	public float WalkSpeed;
	public float RunSpeed;
	private bool alive;
	public RagdollDeath scriptDeath;
	public float WalkMaxX;
	public float WalkMaxY;
	public float WalkMinX;
	public float WalkMinY;
	// Use this for initialization
	void Start () {
		scriptAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<AnimationManagerNPC3D>();
		scriptAgent.updateRotation= false;
		alive = true;
		if(Network.isServer)
			StartCoroutine(CoroutineRoute());
	}
	
	[RPC]
	void SendNextGoal(Vector3 Goal){
		Direction = Goal;
	}
	
	[RPC]
	void SendPositionMurder(Vector3 v){
		Murder = true;
		PositionMurder = v;
	}
	
	
	IEnumerator CoroutineRoute(){
		Direction = this.transform.position;
		while(alive){
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
			anim.Walk(true);
			anim.Idle(false);
		}
		if(this.transform.position.x==Direction.x&&this.transform.position.z== Direction.z){
			anim.Idle(true);
			anim.Walk(false);
		}
	}

	[RPC]
	public void IAmDead(int x){
		if(alive){
			Die ();
		}
		else return;
	}

	public void Die(){
		alive = false;
		scriptAgent.enabled = false;
		anim.anim.enabled = false;
		scriptDeath.DieAnimations();
		networkView.RPC("IAmDead",RPCMode.All,0);
	}

	// Update is called once per frame
	void Update () {
		if(alive){
			scriptAgent.SetDestination(Direction);
			transform.LookAt(new Vector3(Direction.x,this.transform.position.y,Direction.z));
			HandleAnimations ();
		}
	}
}
