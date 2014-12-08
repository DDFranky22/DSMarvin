using UnityEngine;
using System.Collections;

public class TextChangeWithController : MonoBehaviour {

	private GUIText text;
	public string NormalText;
	public string ControllerText;
	// Use this for initialization
	void Start () {
		text = GetComponent<GUIText>();
		if(Input.GetJoystickNames().Length>0){
			text.text = ControllerText;
		}
		else{
			text.text = NormalText;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
