using UnityEngine;
using System.Collections;

public class LMPlayerMovementLobby : MonoBehaviour {
	
	
	public float CooldownAttack;
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
	
	private SpriteRenderer sprite;
	
	private bool Attacked;
	private bool AlreadyAttacked;
	public int Number;
	
	private LMCheckingVictory check;
	
	public bool PlayerOne;

	public LMReady ready;

	public bool Move;

	private bool CanSalute;

	public GameObject PauseMenu;
	public PauseMenuBehaviour pauseScript;
	private bool Pause;
	
	private bool PressedPause;
	
	GameObject tempMenu;

	// Use this for initialization
	void Start () {
		if(Number==0){
			tempMenu = Instantiate(PauseMenu) as GameObject;
		}
		else{
			tempMenu=GameObject.Find("PauseMenu(Clone)") as GameObject;
		}
		pauseScript = tempMenu.GetComponent<PauseMenuBehaviour>();
		Pause = false;
		PressedPause = false;
		animationManager = GetComponent<AnimationManagerPlayer3D>();
		check = Camera.main.GetComponent<LMCheckingVictory>();
		syncStartPosition = this.transform.position;
		Smoothing = WalkSpeed;
		AlreadyAttacked = false;
		ready = GetComponent<LMReady>();
		this.gameObject.name = "Player"+(Number+1);
		Move = true;
		CanSalute = true;
	}
	
	void Run(){
		Smoothing = RunSpeed;
	}
	
	void Walk(){
		Smoothing = WalkSpeed;
	}
	
	IEnumerator Salute(){
		if (!animationManager.SaluteYou ()) {
			Move = false;
			animationManager.Salute (true);
			animationManager.Walk (false);
			animationManager.Idle (false);
			yield return new WaitForSeconds (1.8f);
			CanSalute = true;
			animationManager.Salute (false);
			animationManager.Idle (false);
			Move = true;
		}
	}

	
	void PauseGame(int x){
		pauseScript.PauseGame(x);
	}
	
	void ResumeGame(int x){
		pauseScript.ResumeGame(x);
	}

	void ManagePause(){
		switch(Number){
		case 0: 
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Joystick1Button7)){
				PressedPause = !PressedPause;
				if(!Pause){
					PauseGame(Number);
					Pause = true;
				}
				else{
					ResumeGame(Number);
					Pause = false;
				}
			}
			if(pauseScript.paused){
				if(Input.GetKeyDown(KeyCode.B)||Input.GetKeyDown(KeyCode.Joystick1Button1)){
					pauseScript.QuitCurrentGame(0);
				}
			}
			break;
		case 1: 
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Joystick2Button1)){
				PressedPause = !PressedPause;
				if(!Pause){
					PauseGame(Number);
					Pause = true;
				}
				else{
					ResumeGame(Number);
					Pause = false;
				}
			}
			if(pauseScript.paused){
				if(Input.GetKeyDown(KeyCode.B)||Input.GetKeyDown(KeyCode.Joystick2Button1)){
					pauseScript.QuitCurrentGame(1);
				}
			}
			break;
		case 2: 
			if(Input.GetKeyDown(KeyCode.Joystick3Button7)){
				PressedPause = !PressedPause;
				if(!Pause){
					PauseGame(Number);
					Pause = true;
				}
				else{
					ResumeGame(Number);
					Pause = false;
				}
			}
			if(pauseScript.paused){
				if(Input.GetKeyDown(KeyCode.B)||Input.GetKeyDown(KeyCode.Joystick3Button1)){
					pauseScript.QuitCurrentGame(2);
				}
			}
			break;
		case 3: 
			if(Input.GetKeyDown(KeyCode.Joystick4Button7)){
				PressedPause = !PressedPause;
				if(!Pause){
					PauseGame(Number);
					Pause = true;
				}
				else{
					ResumeGame(Number);
					Pause = false;
				}
			}
			if(pauseScript.paused){
				if(Input.GetKeyDown(KeyCode.B)||Input.GetKeyDown(KeyCode.Joystick4Button1)){
					pauseScript.QuitCurrentGame(3);
				}
			}
			break;
		}
	}



	void Update(){
			ManagePause();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Number==0){
			ready.PlayerNumber = Number;
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
				if(Input.GetAxis("B_"+(Number+1))!=0&&CanSalute){
					CanSalute = false;
					StartCoroutine(Salute());
				}
			}
		}
		else{
			ready.PlayerNumber = Number;
				if(Move){
				if(Input.GetAxis("Horizontal_"+(Number+1)) != 0 || Input.GetAxis("Vertical_"+(Number+1))!=0){
					rigidbody.MovePosition(new Vector3((rigidbody.position.x+(Input.GetAxis("Horizontal_"+(Number+1)))*Time.deltaTime*Smoothing),0.1f,(rigidbody.position.z+(Input.GetAxis("Vertical_"+(Number+1)))*Time.deltaTime*Smoothing)));
					HandleModelRotation(Input.GetAxis("Horizontal_"+(Number+1)),Input.GetAxis("Vertical_"+(Number+1)));
					AnimationMove();
				}
				else{
					AnimationIdle();
				}
				if(Mathf.Abs(Input.GetAxis("RT_"+(Number+1)))==1.0f){
					Run();
				}
				else{
					Walk ();
				}
				if(Input.GetAxis("B_"+(Number+1))!=0&&CanSalute){
					CanSalute = false;
					StartCoroutine(Salute());
				}
			}
		}
	}
	
	void AnimationMove(){
		if(animationManager!=null)
			if(animationManager.IsWalking())
				return;
		animationManager.Walk(true);
		animationManager.Idle(false);
	}
	
	void AnimationIdle(){
		if(!animationManager.IsWalking())
			return;
		animationManager.Walk(false);
		animationManager.Idle(true);
	}
	
	void HandleModelRotation(float Cos, float Sin){
		Vector3 targetDirection = new Vector3(Cos,0.0f,Sin);
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection,Vector3.up);
		Quaternion newrotation = Quaternion.Lerp(rigidbody.rotation,targetRotation,RotationSpeed*Time.deltaTime);
		rigidbody.MoveRotation(newrotation);
		
	}
	
}
