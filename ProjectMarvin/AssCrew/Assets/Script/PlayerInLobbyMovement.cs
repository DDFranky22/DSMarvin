using UnityEngine;
using System.Collections;

public class PlayerInLobbyMovement : MonoBehaviour {
	
	public float Smoothing;
	public float RunSpeed;
	public float WalkSpeed;
	public float RotationSpeed;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	private Quaternion RotationEnd;
	private AnimationManagerPlayer3D animationManager;
	private bool Move;
	private bool CanSalute;
	
	private SpriteRenderer sprite;
	
	private bool Attacked;

	// Use this for initialization
	void Start () {
		RunSpeed = Smoothing*1.5f;
		WalkSpeed = Smoothing;
		animationManager = GetComponent<AnimationManagerPlayer3D>();
		syncStartPosition = this.transform.position;
		Smoothing = WalkSpeed;
		Move = true;
		CanSalute = true;
	}
	
	void Attack(){
		Attacked = true;
	}
	void StopAttack(){
		Attacked = false;
	}
	
	void Run(){
		Smoothing = RunSpeed;
	}
	
	void Walk(){
		Smoothing = WalkSpeed;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(networkView.isMine){
			Movement();
		}
		else{
			SyncedMovement();
		}
	}

	void Movement(){
		if(Move){
			if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical")!=0){
				rigidbody.MovePosition(new Vector3((rigidbody.position.x+(Input.GetAxis("Horizontal"))*Time.deltaTime*Smoothing),0.1f,(rigidbody.position.z+(Input.GetAxis("Vertical"))*Time.deltaTime*Smoothing)));
				HandleModelRotation(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
				AnimationMove();
			}
			else{
				AnimationIdle();
			}
			if(Mathf.Abs(Input.GetAxis("RT_1"))==1.0f){
				Run();
			}
			else{
				Walk ();
			}
			if(Input.GetAxis("B_1")!=0&&CanSalute){
				CanSalute = false;
				StartCoroutine(Salute());
			}
		}
	}

	IEnumerator Salute(){
		if (!animationManager.SaluteYou ()) {
			Move = false;
			animationManager.Salute (true);
			animationManager.Walk (false);
			animationManager.Idle (false);
			yield return new WaitForSeconds (1.8f);
			animationManager.Salute (false);
			animationManager.Idle (false);
			Move = true;
			CanSalute = true;
		}
	}

	void AnimationMove(){
		if(animationManager.IsWalking())
			return;
		networkView.RPC("SetWalk",RPCMode.Others,true);
		animationManager.Walk(true);
		animationManager.Idle(false);
	}
	
	void AnimationIdle(){
		if(!animationManager.IsWalking())
			return;
		networkView.RPC("SetWalk",RPCMode.Others,false);
		animationManager.Walk(false);
		animationManager.Idle(true);
	}
	
	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
		Quaternion newrotation = Quaternion.Lerp(rigidbody.rotation,RotationEnd,RotationSpeed*Time.deltaTime);
		rigidbody.MoveRotation(newrotation);
	}
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		Quaternion Rotation = this.transform.rotation;
		if (stream.isWriting)
		{
			syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);

			Rotation = this.transform.rotation;
			stream.Serialize(ref Rotation);

			syncVelocity = rigidbody.velocity;
			stream.Serialize(ref syncVelocity);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref Rotation);
			stream.Serialize(ref syncVelocity);
			syncTime = 0f;
			RotationEnd = Rotation;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody.position;
		}
	}
	
	void OnPlayerDisconnected(NetworkPlayer player){
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
	
	[RPC]
	void SetWalk(bool v){
		animationManager.Walk(v);
		animationManager.Idle(!v);
	}
	
	void HandleModelRotation(float Cos, float Sin){
		Vector3 targetDirection = new Vector3(Cos,0.0f,Sin);
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection,Vector3.up);
		Quaternion newrotation = Quaternion.Lerp(rigidbody.rotation,targetRotation,RotationSpeed*Time.deltaTime);
		rigidbody.MoveRotation(newrotation);
	}
	
}
