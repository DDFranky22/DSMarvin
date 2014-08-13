using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float Smoothness;
	private string[] Joystick;
	public Vector2 CenterScreen;
	public float OffsetYMovement;
	public float OffsetXMovement;

	public float UpperBoundX;
	public float UpperBoundY;
	public float LowerBoundX;
	public float LowerBoundY;
	// Use this for initialization
	void Start () {
		if(Smoothness<=0){
			Smoothness = 1;
		}
		this.transform.position = new Vector3(Random.Range(LowerBoundX,UpperBoundX),10.0f,Random.Range(LowerBoundY,UpperBoundY));
		Joystick = Input.GetJoystickNames();
		CenterScreen = new Vector2(Screen.width/2,Screen.height/2);
		OffsetXMovement = (CenterScreen.x*2)/3;
		OffsetYMovement = (CenterScreen.y)/2;
		if(Input.GetJoystickNames().Length>0.0f)
			Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x<LowerBoundX){
			this.transform.position = new Vector3(LowerBoundX,10.0f,this.transform.position.z);
		}
		if(this.transform.position.x>UpperBoundX){
			this.transform.position = new Vector3(UpperBoundX,10.0f,this.transform.position.z);
		}
		if(this.transform.position.z<LowerBoundY){
			this.transform.position = new Vector3(this.transform.position.x,10.0f,LowerBoundY);
		}
		if(this.transform.position.z>UpperBoundY){
			this.transform.position = new Vector3(this.transform.position.x,10.0f,UpperBoundY);
		}
		if(Joystick.Length>0.0f)
			transform.position = Vector3.MoveTowards(this.transform.position,this.transform.position+new Vector3(Input.GetAxis("Horizontal_R"),0.0f,Input.GetAxis("Vertical_R")),Time.deltaTime*Smoothness);
		else{
			if(Input.mousePosition.x>=CenterScreen.x+OffsetXMovement){
				transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position+new Vector3(Input.mousePosition.x+CenterScreen.x,0.0f,0.0f),Time.deltaTime*Smoothness);
			}
			if(Input.mousePosition.x<=CenterScreen.x-OffsetXMovement){
				transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position+new Vector3(Input.mousePosition.x-CenterScreen.x,0.0f,0.0f),Time.deltaTime*Smoothness);
			}
			if(Input.mousePosition.y>=CenterScreen.y+OffsetYMovement){
				transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position+new Vector3(0.0f,0.0f,Input.mousePosition.y+CenterScreen.y),Time.deltaTime*Smoothness);
			}
			if(Input.mousePosition.y<=CenterScreen.y-OffsetYMovement){
				transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position+new Vector3(0.0f,0.0f,Input.mousePosition.y-CenterScreen.y),Time.deltaTime*Smoothness);
			}
		}
	}
}
