using UnityEngine;
using System.Collections;

public class DestroyUselessGameObject : MonoBehaviour {

	public string Find;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Joystick1Button1))
			Destroy (GameObject.Find(Find));
	}

	void OnMouseDown(){
		Destroy(GameObject.Find(Find));
	}
}
