using UnityEngine;
using System.Collections;

public class NPCBehaviourMenu : MonoBehaviour {
	
	public Vector3 Direction;
	NavMeshAgent scriptAgent;
	public GameObject ball;
	public static bool Murder;
	public static Vector3 PositionMurder;
	public AnimationManagerNPC3D anim;
	
	// Use this for initialization
	void Start () {
		scriptAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<AnimationManagerNPC3D>();
		scriptAgent.updateRotation= false;
		StartCoroutine(CoroutineRoute());
	}

	IEnumerator CoroutineRoute(){
		Direction = this.transform.position;
		while(true){
			Direction = new Vector3(Random.Range(-8.0f,8.0f),0.0f,Random.Range(-7.0f,7.0f));
			if(Random.Range(0.0f,1.0f)>0.7f){
				scriptAgent.speed = 3.5f;
			}
			else
				scriptAgent.speed = 3.5f/1.5f;
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
	
	// Update is called once per frame
	void Update () {
		scriptAgent.SetDestination(Direction);
		transform.LookAt(new Vector3(Direction.x,this.transform.position.y,Direction.z));
		HandleAnimations ();
	}
}
