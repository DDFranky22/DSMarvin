using UnityEngine;
using System.Collections;

public class StayInPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = Quaternion.Euler(new Vector3(-35.0f,-138.0f,0.0f));
	}
}
